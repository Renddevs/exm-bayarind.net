namespace Vleko.Bayarind.Web.Models
{
    public class MenuModel
    {
        public string MenuName { get; set; }
        public string Url { get; set; }
        public string Controllers { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public bool NeedLogin { get; set; }
        public List<string> AccessRole { get; set; }
        public List<MenuModel> ChildMenu { get; set; }
    }
}
