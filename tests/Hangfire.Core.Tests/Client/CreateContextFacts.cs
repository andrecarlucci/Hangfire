﻿using System;
using System.Collections.Generic;
using Hangfire.Client;
using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;
using Moq;
using Xunit;

namespace Hangfire.Core.Tests.Client
{
    public class CreateContextFacts
    {
        private readonly Job _job;
        private readonly Mock<IState> _state;
        private readonly Mock<IStorageConnection> _connection;
        private readonly Mock<IStateMachine> _stateMachine;
        private readonly Mock<IStateMachineFactory> _stateMachineFactory;

        public CreateContextFacts()
        {
            _job = Job.FromExpression(() => Method());
            _state = new Mock<IState>();
            _connection = new Mock<IStorageConnection>();
            _stateMachine = new Mock<IStateMachine>();

            _stateMachineFactory = new Mock<IStateMachineFactory>();
            _stateMachineFactory.Setup(x => x.Create(It.IsNotNull<IStorageConnection>()))
                .Returns(_stateMachine.Object);
        }

        [Fact]
        public void Ctor_ThrowsAnException_WhenConnectionIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => new CreateContext(null, _stateMachineFactory.Object, _job, _state.Object));

            Assert.Equal("connection", exception.ParamName);
        }

        [Fact]
        public void Ctor_ThrowsAnException_WhenStateMachineFactoryIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => new CreateContext(_connection.Object, null, _job, _state.Object));

            Assert.Equal("stateMachineFactory", exception.ParamName);
        }

        [Fact]
        public void Ctor_ThrowsAnException_WhenJobIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => new CreateContext(_connection.Object, _stateMachineFactory.Object, null, _state.Object));

            Assert.Equal("job", exception.ParamName);
        }

        [Fact]
        public void Ctor_ThrowsAnException_WhenStateIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => new CreateContext(
                    _connection.Object, _stateMachineFactory.Object, _job, null));

            Assert.Equal("initialState", exception.ParamName);
        }

        [Fact]
        public void Ctor_CorrectlyInitializes_AllProperties()
        {
            var context = CreateContext();

            Assert.Same(_connection.Object, context.Connection);
            Assert.Same(_job, context.Job);
            Assert.Same(_state.Object, context.InitialState);

            Assert.NotNull(context.Items);
            Assert.Null(context.JobId);
        }

        [Fact]
        public void CopyCtor_CopiesItemsDictionary_FromTheGivenContext()
        {
            var context = CreateContext();
            var contextCopy = new CreateContext(context);

            Assert.Same(context.Items, contextCopy.Items);
        }

        [Fact]
        public void CopyCtor_CopiesJobId_FromTheGivenContext()
        {
            var context = CreateContext();
            var contextCopy = new CreateContext(context);

            Assert.Same(context.JobId, contextCopy.JobId);
        }

        [Fact]
        public void SetJobParameter_ThrowsAnException_WhenParameterNameIsNull()
        {
            var context = CreateContext();
            var exception = Assert.Throws<ArgumentNullException>(
                () => context.SetJobParameter(null, null));

            Assert.Equal("name", exception.ParamName);
        }

        [Fact]
        public void SetJobParameter_AcceptsNullValues()
        {
            var context = CreateContext();

            Assert.DoesNotThrow(
                () => context.SetJobParameter("name", null));
        }

        [Fact]
        public void SetJobParameter_CanBeCalledTwice_WithTheSameName()
        {
            var context = CreateContext();
            context.SetJobParameter("name", null);

            Assert.DoesNotThrow(
                () => context.SetJobParameter("name", null));
        }

        [Fact]
        public void GetJobParameter_ThrowsAnException_WhenParameterNameIsNull()
        {
            var context = CreateContext();
            Assert.Throws<ArgumentNullException>(
                () => context.GetJobParameter<int>(null));
        }

        [Fact]
        public void GetJobParameter_ReturnsDefaultValue_IfParameterDoesNotExists()
        {
            var context = CreateContext();

            Assert.Equal(default(int), context.GetJobParameter<int>("one"));
            Assert.Equal(default(string), context.GetJobParameter<string>("two"));
        }

        [Fact]
        public void GetJobParameter_ReturnsTheValue_ThatWasSetByTheCorrespondingMethod()
        {
            var context = CreateContext();
            context.SetJobParameter("name", "value");

            Assert.Equal("value", context.GetJobParameter<string>("name"));
        }

        [Fact]
        public void GetJobParameter_ReturnsTheValue_OfTheSpecifiedParameterNameOnly()
        {
            var context = CreateContext();

            context.SetJobParameter("name1", "value1");
            context.SetJobParameter("name2", "value2");

            Assert.Equal("value1", context.GetJobParameter<string>("name1"));
        }

        [Fact]
        public void GetJobParameter_ReturnsTheFreshestValue_WhenTwoSetOperationsPerformed()
        {
            var context = CreateContext();

            context.SetJobParameter("name", "oldValue");
            context.SetJobParameter("name", "newValue");

            Assert.Equal("newValue", context.GetJobParameter<string>("name"));
        }

        [Fact]
        public void GetJobParameter_ThrowsAnException_WhenParameterCouldNotBeDeserialized()
        {
            var context = CreateContext();

            context.SetJobParameter("name", "value");

            Assert.Throws<InvalidOperationException>(
                () => context.GetJobParameter<int>("name"));
        }

        [Fact]
        public void CopyCtor_CopiesJobParameters_FromTheGivenContext()
        {
            var context = CreateContext();
            context.SetJobParameter("name", "value");
            var contextCopy = new CreateContext(context);

            var value = contextCopy.GetJobParameter<string>("name");

            Assert.Equal("value", value);
        }

        [Fact]
        public void CreateJob_DelegatesItsExecution_ToStateMachine()
        {
            var context = CreateContext();

            context.CreateJob();

            _stateMachine.Verify(x => x.CreateInState(
                context.Job,
                It.IsNotNull<Dictionary<string, string>>(),
                context.InitialState));
        }

        [Fact]
        public void CreateJob_SetsTheJobIdProperty()
        {
            var context = CreateContext();
            _stateMachine
                .Setup(x => x.CreateInState(context.Job, It.IsAny<Dictionary<string, string>>(), context.InitialState))
                .Returns("id");

            context.CreateJob();

            Assert.Equal("id", context.JobId);
        }

        [Fact]
        public void CreateJob_PassesParametersAsJsonObjects()
        {
            var context = CreateContext();
            context.SetJobParameter("name", new { key = "value" });

            context.CreateJob();

            _stateMachine.Verify(x => x.CreateInState(
                It.IsAny<Job>(),
                It.Is<Dictionary<string, string>>(
                    d => d.ContainsKey("name") && d["name"] == "{\"key\":\"value\"}"),
                It.IsAny<IState>()));
        }

        [Fact]
        public void SetJobParameter_ThrowsAnException_AfterCreateJobWasCalled()
        {
            var context = CreateContext();
            context.CreateJob();

            Assert.Throws<InvalidOperationException>(
                () => context.SetJobParameter("name", "value"));
        }

        [Fact]
        public void GetJobParameter_DoesNotThrowAnException_AfterCreateJobWasCalled()
        {
            var context = CreateContext();

            context.CreateJob();

            Assert.DoesNotThrow(
                () => context.GetJobParameter<string>("name"));
        }

        [Fact]
        public void CopyCtor_CopiesJobId_WhenItWasSet()
        {
            _stateMachine.Setup(x => x.CreateInState(
                _job, It.IsAny<Dictionary<string, string>>(), _state.Object))
                .Returns("id");

            var context = CreateContext();
            context.CreateJob();

            var contextCopy = new CreateContext(context);

            Assert.Equal("id", contextCopy.JobId);
        }

        [Fact]
        public void CopyCtor_CopiesTheFactThatJobWasCreated()
        {
            var context = CreateContext();
            context.CreateJob();

            var contextCopy = new CreateContext(context);

            Assert.Throws<InvalidOperationException>(
                () => contextCopy.SetJobParameter("name", "value"));
        }

        public static void Method()
        {
        }

        private CreateContext CreateContext()
        {
            return new CreateContext(
                _connection.Object, _stateMachineFactory.Object, _job, _state.Object);
        }
    }
}
