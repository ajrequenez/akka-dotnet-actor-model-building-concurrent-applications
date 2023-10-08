using Akka.Actor;
using MovieStreaming.Common.Messages;

namespace MovieStreaming.Common.Actors
{
    public class PlaybackStatisticsActor : ReceiveActor
    {
        public PlaybackStatisticsActor() 
        {
            Context.ActorOf(MoviePlayCounterActor.Props(), "MoviePlayCounter");
        }

        #region Lifecycle Hooks
        protected override void PreStart()
        {
            ColorConsole.WriteLineMagenta("PlaybackStatisticsActor Prestart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineMagenta("PlaybackStatisticsActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineMagenta(
                string.Format("PlaybackStatisticsActor PreRestart because: {0}", reason));
            base.PreRestart(reason, message);
        }
        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineMagenta(
                string.Format("PlaybackStatisticsActor PostRestart because: {0}", reason));
            base.PostRestart(reason);
        }
        #endregion

        public static Props Props() => Akka.Actor.Props.Create(() => new PlaybackStatisticsActor());
    }
}
