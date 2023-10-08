using Akka.Actor;
using MovieStreaming.Common.Messages;

namespace MovieStreaming.Common.Actors
{
    public class UserActor : ReceiveActor
    {
        private string? _currentlyWatching;
        private int _userId;

        public UserActor(int userId)
        {
            _userId = userId;

            Console.WriteLine("Creating User Actor {0}", userId);
            ColorConsole.WriteLineCyan("Setting user actor to initial state of Stopped");

            Stopped();
        }

        private void Playing()
        {
            Receive<PlayMovieMessage>(_ => ColorConsole.WriteLineRed("Error: Cannot start movie until stopping existing"));
            Receive<StopMovieMessage>(_ => StopPlayingMovie());
        }

        private void Stopped()
        {
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.MovieTitle));
            Receive<StopMovieMessage>(_ => ColorConsole.WriteLineRed("Error: cannot stop if nothing is currenlty playing"));
        }
        private void StartPlayingMovie(string title)
        {
            _currentlyWatching = title;

            ColorConsole.WriteLineYellow(
                string.Format("User is currently watching: {0}", title));

            Context.ActorSelection("/user/Playback/PlaybackStatistics/MoviePlayCounter")
                .Tell(new IncrementPlayCountMessage(title));
            Become(Playing);

            ColorConsole.WriteLineYellow(string.Format("UserActor {0} has now become Playing", _userId));
        }

        private void StopPlayingMovie()
        {
            ColorConsole.WriteLineYellow(
                string.Format("User stopped watching {0}", _currentlyWatching));

            _currentlyWatching = null;

            Become(Stopped);
            ColorConsole.WriteLineYellow(string.Format("UserActor {0} has now become Stopped", _userId));
        }

        #region Lifecycle Hooks
        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("UserActor Prestart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("UserActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen(
                string.Format("UserActor PreRestart because: {0}", reason));
            base.PreRestart(reason, message);
        }
        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen(
                string.Format("UserActorr PostRestart because: {0}", reason));
            base.PostRestart(reason);
        }
        #endregion

        public static Props Props(int userId) => Akka.Actor.Props.Create(() =>  new UserActor(userId));
    }
}
