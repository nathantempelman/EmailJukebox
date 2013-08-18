using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MischeviousEmailSending
{
    class EmailJukebox
    {
        static void Main(string[] args)
        {

            String troublemakerEmailAddress; 
            String troublemakerName;
            String troublemakerPassword; 
            String botheredRecipientEmailAddress;

            Console.WriteLine("Enter the gmail address you want to use.");
            troublemakerEmailAddress = Console.ReadLine();
            Console.WriteLine("\nEnter password for the gmail account.");
            troublemakerPassword = Console.ReadLine();
            Console.WriteLine("\nEnter the name you want to send this email song as.");
            troublemakerName = Console.ReadLine();
            Console.WriteLine("\nEnter the email address you'd like to send it to");
            botheredRecipientEmailAddress = Console.ReadLine();

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            MailAddress from = new MailAddress(troublemakerEmailAddress, troublemakerName);
            MailAddress to = new MailAddress(botheredRecipientEmailAddress);
            MailMessage message = new MailMessage(from, to);
            NetworkCredential myCreds = new NetworkCredential(troublemakerEmailAddress, troublemakerPassword, "");
            client.Credentials = myCreds;

            message.Body = "<---------------";
            String[] songs ={
        

//Lionel Richie - Hello
@"I've been alone with you
Inside my mind
And in my dreams I've kissed your lips
A thousand times
I sometimes see you
Pass outside my door

Hello!
Is it me you're looking for?
I can see it in your eyes
I can see it in your smile
You're all I've ever wanted
And my arms are open wide
'cause you know just what to say
And you know just what to do
And I want to tell you so much
I love you

I long to see the sunlight in your hair
And tell you time and time again
How much I care
Sometimes I feel my heart will overflow
Hello!
I've just got to let you know
'cause I wonder where you are
And I wonder what you do
Are you somewhere feeling lonely?
Or is someone loving you?
Tell me how to win your heart
For I haven't got a clue
But let me start by saying I love you

Hello!
Is it me you're looking for?
'cause I wonder where you are
And I wonder what you do
Are you somewhere feeling lonely?
Or is someone loving you?
Tell me how to win your heart
For I haven't got a clue
But let me start by saying I love you"
            ,

//Rick Astley - Never Gonna Give You Up
@"We're no strangers to love
You know the rules and so do I
A full commitment's what I'm thinking of
You wouldn't get this from any other guy

I just wanna tell you how I'm feeling
Gotta make you understand

Never gonna give you up
Never gonna let you down
Never gonna run around and desert you
Never gonna make you cry
Never gonna say goodbye
Never gonna tell a lie and hurt you

We've known each other for so long
Your heart's been aching, but
You're too shy to say it
Inside, we both know what's been going on
We know the game and we're gonna play it

And if you ask me how I'm feeling
Don't tell me you're too blind to see

Never gonna give you up
Never gonna let you down
Never gonna run around and desert you
Never gonna make you cry
Never gonna say goodbye
Never gonna tell a lie and hurt you

Never gonna give you up
Never gonna let you down
Never gonna run around and desert you
Never gonna make you cry
Never gonna say goodbye
Never gonna tell a lie and hurt you

(Ooh, give you up)
(Ooh, give you up)
Never gonna give, never gonna give
(Give you up)
Never gonna give, never gonna give
(Give you up)

We've known each other for so long
Your heart's been aching, but
You're too shy to say it
Inside, we both know what's been going on
We know the game and we're gonna play it

I just wanna tell you how I'm feeling
Gotta make you understand

Never gonna give you up
Never gonna let you down
Never gonna run around and desert you
Never gonna make you cry
Never gonna say goodbye
Never gonna tell a lie and hurt you

Never gonna give you up
Never gonna let you down
Never gonna run around and desert you
Never gonna make you cry
Never gonna say goodbye
Never gonna tell a lie and hurt you

Never gonna give you up
Never gonna let you down
Never gonna run around and desert you
Never gonna make you cry
Never gonna say goodbye
Never gonna tell a lie and hurt you"
                            ,
@"Hello Nathan
This is your computer
feed me cats"};

            int songChoice = -1;
            while (songChoice < 0 || songs.Length <= songChoice)
            {
                Console.WriteLine("\nPress 0 for Hello by Lionel Richie, or 1 for Never Gonna Give You Up by Rick Astley.");
                songChoice = Int32.Parse(Console.ReadLine());
                Console.WriteLine("You entered: " + songChoice);
            }
            
            String[] songarray = songs[songChoice].Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            for (int i = songarray.Length - 1; i >= 0; i--)
            {
                message.Subject = "♪♪♪ "+songarray[i]+" ♪♪♪";
                try
                {
                    client.Send(message);
                    Console.WriteLine("Sent " + message.Subject);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problem sending. Error: " + ex.ToString());
                }

            }
            Console.WriteLine("Done sending, press enter to finish.");
            Console.Read();


/*

*/


        }
    }
}
