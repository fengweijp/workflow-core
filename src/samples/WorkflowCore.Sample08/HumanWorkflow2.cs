﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Sample08
{
    public class HumanWorkflow2 : IWorkflow
    {
        public string Id
        {
            get
            {
                return "HumanWorkflow";
            }
        }

        public int Version
        {
            get
            {
                return 1;
            }
        }

        public void Build(IWorkflowBuilder<object> builder)
        {
            var step1 = builder.StartWith(context => ExecutionResult.Next());
            var step2 = step1.UserStep("Do you approve", data => "MYDOMAIN\\daniel");
            step2
                .When("yes", "I approve")
                .Then(context =>
                {
                    Console.WriteLine("You approved");
                    return ExecutionResult.Next();
                });

            step2
                .When("no", "I do not approve")
                .Then(context =>
                {
                    Console.WriteLine("You did not approve");
                    return ExecutionResult.Next();
                });

        }
    }
}

