using System;
using System.Text;

namespace WordpressAutomation
{
    public class PostCreator
    {
        private static string CreateBody()
        {
            return CreateRandomString() + ", body";
        }

        private static string CreateTitle()
        {
            return CreateRandomString() + ", title";
        }

        public static void Initialize()
        {
            PreviousBody = null;
            PreviousTitle = null;
        }

        private static string CreateRandomString()
        {
            var sb = new StringBuilder();
            var random = new Random();
            var cycles = random.Next(5 + 1);
            for (int i = 0; i < cycles; i++)
            {
                sb.Append(Words[random.Next(Words.Length)]);
                sb.Append(" ");
                sb.Append(Articles[random.Next(Articles.Length)]);
                sb.Append(" ");
                sb.Append(Words[random.Next(Words.Length)]);
                sb.Append(" ");
            }

            return sb.ToString();
        }

        public static void CleanUp()
        {
            if (IsPostCreated)
            {
                TrashPost();
            }
        }

        private static void TrashPost()
        {
            ListPostPage.TrashPost(PreviousTitle);
            Initialize();
        }

        private static string[] Words = new[]
        {
            "boy", "cat", "dog", "rabbit", "baseball", "throw", "find", "scary", "funny", "mustard"
        };

        private static string[] Articles = new[]
        {
            "the", "an", "and", "a", "of", "to", "it", "as"
        };

        public static string PreviousBody { get; set; }
        public static string PreviousTitle { get; set; }

        public static bool IsPostCreated
        {
            get
            {
                return !string.IsNullOrEmpty(PreviousTitle);
            }
        }

        public static void CreatePost()
        {
            NewPostPage.GoTo();

            PreviousTitle = CreateTitle();
            PreviousBody = CreateBody();

            NewPostPage.CreatePost(PreviousTitle)
                .WithBody(PreviousBody)
                .Publish();
        }
    }
}