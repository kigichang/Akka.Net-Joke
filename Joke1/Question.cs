using System;
namespace Joke1.Question
{
	public sealed class Interest
	{
		private static readonly Interest instance = new Interest();

		private Interest()
		{
		}

		public static Interest Instance
		{
			get
			{
				return instance;
			}
		}
	}


	public sealed class Why
	{
		private static readonly Why instance = new Why();

		private Why()
		{
		}


		public static Why Instance
		{
			get
			{
				return instance;
			}
		}

	}

}

