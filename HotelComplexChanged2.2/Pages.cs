using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace HotelComplexChanged2._2
{
    public static class Pages
    {
        static Db db;

        static Dictionary<PageType, Page> pages = new Dictionary<PageType, Page>();

        static Dictionary<PageType, (Type, Type)> pageTypes = new Dictionary<PageType, (Type, Type)>();

        public static event EventHandler<PageType> CurrentPageChanged;

        public static void RegisterPageType(PageType type, Type pageType, Type vmType)
        {
            if (pageTypes.ContainsKey(type))
                throw new Exception("Заданный тип страницы уже зарегистрирован");
            pageTypes.Add(type, (pageType, vmType));
        }

        public static void SetModel(Db db)
        {
            Pages.db = db;
        }

        static Pages()
        {
            // RegisterPageType(PageType.MainWindow, typeof(MainWindow), typeof(MainWindowVM));
            // PageClientList PageRoomList PageStaffList PageCleaningList PageReserList
            RegisterPageType(PageType.PageClientList, typeof(PageClientList), typeof(VMClientList));
            RegisterPageType(PageType.PageCleaningList, typeof(PageCleaningList), typeof(VMCleaningList));
            RegisterPageType(PageType.PageReserList, typeof(PageReserList), typeof(VMReserList));
            RegisterPageType(PageType.PageRoomList, typeof(PageRoomList), typeof(VMRoomList));
            RegisterPageType(PageType.PageStaffList, typeof(PageStaffList), typeof(VMStaffList));
        }

        public static void ChangePageTo(PageType type)
        {
            CurrentPageChanged?.Invoke(null, type);
        }
    }
}
