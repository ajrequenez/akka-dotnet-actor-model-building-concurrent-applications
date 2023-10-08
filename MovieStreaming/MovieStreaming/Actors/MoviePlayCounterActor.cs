using Akka.Actor;
using MovieStreaming.Messages;

namespace MovieStreaming.Actors
{
    public class MoviePlayCounterActor : ReceiveActor
    {
        private readonly Dictionary<string, int> _moviePlayCounts;
        public MoviePlayCounterActor() 
        {
            _moviePlayCounts = new Dictionary<string, int>();

            Receive<IncrementPlayCountMessage>(HandleIncrementPlayCountMessage);
        }

        private void HandleIncrementPlayCountMessage(IncrementPlayCountMessage message)
        {
            if(_moviePlayCounts.ContainsKey(message.MovieTitle))
            {
                _moviePlayCounts[message.MovieTitle]++;
            }
            else
            {
                _moviePlayCounts.Add(message.MovieTitle, 1);
            }

            ColorConsole.WriteLineGreen(
                string.Format("{0}: has been played {1} time(s)"
                    , message.MovieTitle
                    , _moviePlayCounts[message.MovieTitle]
                    ));
        }

        #region Lifecycle Hooks
        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("MoviePlayCounterActor Prestart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("MoviePlayCounterActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen(
                string.Format("MoviePlayCounterActor PreRestart because: {0}", reason));
            base.PreRestart(reason, message);
        }
        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen(
                string.Format("MoviePlayCounterActor PostRestart because: {0}", reason));
            base.PostRestart(reason);
        }
        #endregion

        public static Props Props() => Akka.Actor.Props.Create(() => new MoviePlayCounterActor());
    }
}
