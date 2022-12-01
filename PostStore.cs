
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace guestbook
{
	public class PostStore
	{
        //spara filnamn i variabel
        private string filename = @"poststore.json";
        //skapar en ny lista
        private List<Post> posts = new List<Post>();

		//funktion för att kontrollera om filen existera och spara till lista
        public PostStore()
		{
            if (File.Exists(@"poststore.json") == true)
            { 
                string jsonString = File.ReadAllText(filename);
                posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!;
            }
        }
        //funktion för spara posten till jsonfilen
        public Post AddPost(Post post)
        {
            posts.Add(post);
            Marshal();
            return post;
        }
        
        //funktion för radera posten i jsonfilen
        public int DelPost(int index)
        {
            posts.RemoveAt(index);
            Marshal();
            return index;
        }
        //hämtar alla poster i listan
        public List<Post> GetPosts()
        {
            return posts;
        }
        private void Marshal()
        {
            // serialisera alla och hämta listan från json-filen
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }
    }
}

