using guestbook;

class Program
{
    static void Main(string[] args)
    {
        //skspar ny instans av poststore
        PostStore poststore = new PostStore();
        int i = 0;
        //loppar igenom så länge loppar går som true
        while (true)
        {
            //rensar skärmen
            Console.Clear();

            Console.CursorVisible = false;
            //frågor som loopas igenom
            Console.WriteLine("GÄSTBOKEN\n\n");
            Console.WriteLine("1. Göra ett inlägg");
            Console.WriteLine("2. Ta bort ett inlägg\n");
            Console.WriteLine("X. Avsluta\n");

            //sätter index som 0
            i = 0;

            //loppar igenom arrayen och skriver ut på skärmen
            foreach (Post post in poststore.GetPosts())
            {
                Console.WriteLine($"[{i++}] {post.Author} - {post.Content}");
            }

            int inp = (int)Console.ReadKey(true).Key;

            //switch-sats med olika påståenden
            switch (inp)
            {
                case '1':

                    Console.CursorVisible = true;

                    Console.Write("Ange ditt namn: ");
                    //sparar input i variabel
                    string? author = Console.ReadLine();

                    Console.Write("Gör ett inlägg: ");
                    //sparar input i variabel
                    string? content = Console.ReadLine();

                    //skapar ny instans av post-klassen
                    Post obj = new Post();

                    //kontroll om angiven sträng är tom eller inte
                    if (!String.IsNullOrEmpty(author) && !String.IsNullOrEmpty(content))
                    {
                        //sparar i variabel
                        obj.Author = author;
                        obj.Content = content;
                        //lagrar i json-filen
                        poststore.AddPost(obj);
                    }
                    else
                    {
                        //meddelande ifall inputvärde är tomt
                        Console.WriteLine("\nBåde namn och inlägg måste fyllas i, var god försök igen!\nTryck ENTER för att fortsätta.");
                        Console.ReadLine();
                    }

                    break;
                case '2':
                    Console.CursorVisible = true;
                    Console.Write("Ange index att radera: ");
                    //spara angivet input i variabel och raderar psot beroende på index
                    string? index = Console.ReadLine();
                    poststore.DelPost(Convert.ToInt32(index));
                    break;
                case 88:
                    //bryter loopen
                    Environment.Exit(0);
                    break;
            }
        }
    }
}