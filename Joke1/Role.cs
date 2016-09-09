using System;
using Akka;
using Akka.Actor;
using Joke1.Answer;
using Joke1.Question;

namespace Joke1.Role
{
	public class Penguin : ReceiveActor
	{
		public string Name { get; private set; }

		public Penguin(string name)
		{
			Name = name;

			Receive<Interest>(interest => Sender.Tell(new Three(Name, "吃飯", "睡覺", "打東東")));
		}

		public static Props Props(string name)
		{
			return Akka.Actor.Props.Create<Penguin>(() => new Penguin(name));
		}

		protected override void PreStart()
		{
			base.PreStart();
			Console.WriteLine($"{Name} start!!!");
		}
	}




	public class DongDong : Penguin 
	{
		private void DongReceive()
		{
			Receive<Interest>(interest => Sender.Tell(new Two(Name, "吃飯", "睡覺")));
			Receive<Why>(why => Sender.Tell(new Because(Name, "我就是東東")));
		}

		public DongDong() : base("東東")
		{
			Become(DongReceive);	
		}


		public static Props Props()
		{
			return Akka.Actor.Props.Create<DongDong>();
		}
	}


	public class Reporter : ReceiveActor
	{
		public Reporter()
		{
			Receive<Three>(three => Console.WriteLine(three));

			Receive<Two>(two => { Console.WriteLine(two); Sender.Tell(Why.Instance); });

			Receive<Because>(because => Console.WriteLine(because));

		}

		public static Props Props()
		{
			return Akka.Actor.Props.Create<Reporter>();
		}
	}
}
