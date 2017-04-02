# XPO Connections #


## Clear DB ##

    Session.DefaultSession.ClearDatabase();

## Default: ##

    XpoDefault.DataLayer = XpoDefault.GetDataLayer(ConnectionString, AutoCreateOption.DatabaseAndSchema);

    using(XPCollection collection = new XPCollection(Session.DefaultSession, typeof(SampleObject))) 
    {
    ...
    }


or

    private static void InitDAL() {
       DevExpress.Xpo.XpoDefault.DataLayer = DevExpress.Xpo.XpoDefault.GetDataLayer(
       DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString(@"c:\database\customer.mdb"),
       DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
    

## XPCollection ##

    using(XPCollection collection = new XPCollection(Session.DefaultSession, typeof(SampleObject))) {
    // Loop through all the objects. 
        foreach(SampleObject theObject in collection) {
            theObject.Data = new String('@', 1024);
            theObject.Save();
            ++i;
            if(i % 100 == 0)
                // Every 100 objects write out memory used. 
                Console.WriteLine(String.Format("    Object {0}, memory allocated {1}", i, 
                  GC.GetTotalMemory(true)));
        }
    }


## Unit of Work ##

Basic usage with Top5 and  sorting.x

    using (var uow = new UnitOfWork())
    {
        XPCollection<Albums> getRecords = new XPCollection<Albums>(uow, CriteriaOperator.Parse("Albumid == 1"));
        
        // or

        XPCollection<Albums> getRecords = new XPCollection<Albums>(uow);

        // sorting and top5.
        // https://documentation.devexpress.com/#CoreLibraries/CustomDocument2130
        getRecords.Sorting.Add(new SortProperty("Albumid", SortingDirection.Ascending));
        getRecords.TopReturnedObjects = 5;
        getRecords.DisplayableProperties = "Albumid;Title;Artistid.Name";

        MyGrid.ItemsSource = getRecords;
        
        ;
    }


## Cursor ##

    XPCursor cursor = new XPCursor(Session.DefaultSession, typeof(SampleObject));
    cursor.PageSize = 100;
    // Loop through all the objects. 
    foreach(SampleObject theObject in cursor) {
        theObject.Data = new String('!', 1024);
        theObject.Save();
        ++i;
         // Every 100 objects write out memory used. 
        if(i % 100 == 0)
    Console.WriteLine(String.Format("Object {0}, memory allocated {1}", i, GC.GetTotalMemory(true)));
    }


