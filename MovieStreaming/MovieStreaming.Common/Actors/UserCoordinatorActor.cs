using Akka.Actor;
using MovieStreaming.Common.Messages;

namespace MovieStreaming.Common.Actors
{
    public class UserCoordinatorActor : ReceiveActor
    {
        private readonly Dictionary<int, IActorRef> _users;

        public UserCoordinatorActor() {
            _users = new Dictionary<int, IActorRef>();

            Receive<PlayMovieMessage>(message =>
            {
                CreateChildUserIfNotExists(message.UserId);
                IActorRef childUser = _users[message.UserId];

                childUser.Tell(message);
            });

            Receive<StopMovieMessage>(message =>
            {
                CreateChildUserIfNotExists(message.UserId);
                IActorRef childUser = _users[message.UserId];

                childUser.Tell(message);
            });
        }

        private void CreateChildUserIfNotExists(int userId)
        {
            if (!_users.ContainsKey(userId))
            {
                IActorRef user = Context.ActorOf(UserActor.Props(userId), "user-" + userId);
                _users.Add(userId, user);

                ColorConsole.WriteLineCyan(
                    string.Format("UserCoordinatorActor created new child UserActor for {0} "
                        + "(Total Users: {1})", userId, _users.Count));
            }

        }
        #region Lifecycle Hooks
        protected override void PreStart()
        {
            ColorConsole.WriteLineCyan("Playback Actor Prestart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineCyan("Playback Actor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineCyan(
                string.Format("Playback Actor PreRestart because: {0}", reason));
            base.PreRestart(reason, message);
        }
        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineCyan(
                string.Format("Playback Actor PostRestart because: {0}", reason));
            base.PostRestart(reason);
        }
        #endregion

        public static Props Props() => Akka.Actor.Props.Create(() => new UserCoordinatorActor());
    }
}
