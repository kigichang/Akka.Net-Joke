using System;

using Akka;
using Akka.Actor;
using Joke1.Question;
using Joke1.Answer;
using Joke1.Role;

namespace Joke1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var system = ActorSystem.Create("Joke");

			var reporter = system.ActorOf(Reporter.Props());

			IActorRef[] penguins = new IActorRef[10];

			int i = 1;
			for (; i <= 9; i++)
			{
				penguins[i - 1] = system.ActorOf(Penguin.Props($"Penguin {i}"));
			}

			penguins[i-1] = system.ActorOf(DongDong.Props());


			foreach (IActorRef penguin in penguins)
			{
				penguin.Tell(Interest.Instance, reporter);
			}

			Console.ReadLine();
			//system.WhenTerminated.Wait();
			Console.WriteLine("End !!!");
		}
	}
}
