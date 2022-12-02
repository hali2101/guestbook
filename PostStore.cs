
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

        //konstruerare för att kontrollera om filen existerar och spara till lista
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
            Storedata();
            return post;
        }

        //funktion för radera posten i jsonfilen
        public int DelPost(int index)
        {
            posts.RemoveAt(index);
            Storedata();
            return index;
        }
        //hämtar alla poster i listan
        public List<Post> GetPosts()
        {
            return posts;
        }
        //metod för att serialisera data till jsonfilen
        private void Storedata()
        {
            // serialisera alla och hämta listan från json-filen
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }
    }
}

