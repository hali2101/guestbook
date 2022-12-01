


namespace guestbook
{
	public class Post
	{
		//sparar i variabler
		public string author = "";
		public string content = "";

		public string Author
		{	
			//setters and getters på namnet
			set { this.author = value; }
			//returnerar värdet på namnet
			get { return this.author; }
		}

		public string Content
		{
			//setters and getters på inlägget
            set { this.content = value; }
			//returnerar värdet på inlägget
            get { return this.content; }
        }
    }
}

