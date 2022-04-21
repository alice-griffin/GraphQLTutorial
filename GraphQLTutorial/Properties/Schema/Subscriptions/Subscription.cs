using GraphQLTutorial.Properties.Schema.Mutations;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTutorial.Properties.Schema.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

        [SubscribeAndResolve]
        public ValueTask<ISourceStream<CourseResult>> CourseUpdated(Guid id, [Service] ITopicEventReceiver topicEventReceiver)
        {
            return topicEventReceiver.SubscribeAsync<string, CourseResult>($"{id}_{nameof(Subscription.CourseUpdated)}");
        }
    }
}
