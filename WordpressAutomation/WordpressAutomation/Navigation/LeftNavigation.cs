namespace WordpressAutomation
{
    public class LeftNavigation
    {
        public class Posts
        {
            public class AddNew
            {
                public static void Select()
                {
                    MenuSelector.Select("wp-menu-name", "Add New");
                }
            }
        }

        public class Pages
        {
            public class AllPages
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-pages", "All Pages");
                }
            }
        }
    }
}