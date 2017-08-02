namespace BeYourMarket.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        RegisterIP = c.String(),
                        LastAccessDate = c.DateTime(nullable: false),
                        LastAccessIP = c.String(),
                        DateOfBirth = c.DateTime(),
                        AcceptEmail = c.Boolean(nullable: false),
                        Gender = c.String(),
                        LeadSourceID = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Disabled = c.Boolean(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ListingReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Description = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                        ListingID = c.Int(),
                        OrderID = c.Int(),
                        UserFrom = c.String(nullable: false, maxLength: 128),
                        UserTo = c.String(nullable: false, maxLength: 128),
                        Active = c.Boolean(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Spam = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserFrom)
                .ForeignKey("dbo.AspNetUsers", t => t.UserTo)
                .ForeignKey("dbo.Listings", t => t.ListingID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.ListingID)
                .Index(t => t.OrderID)
                .Index(t => t.UserFrom)
                .Index(t => t.UserTo);
            
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        Description = c.String(),
                        CategoryID = c.Int(nullable: false),
                        ListingTypeID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                        Price = c.Double(),
                        Currency = c.String(maxLength: 3, fixedLength: true),
                        ContactName = c.String(nullable: false, maxLength: 200),
                        ContactEmail = c.String(nullable: false, maxLength: 200),
                        ContactPhone = c.String(maxLength: 50),
                        ShowPhone = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        ShowEmail = c.Boolean(nullable: false),
                        Premium = c.Boolean(nullable: false),
                        Expiration = c.DateTime(nullable: false),
                        IP = c.String(nullable: false, maxLength: 50),
                        Location = c.String(maxLength: 250),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.ListingTypes", t => t.ListingTypeID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.ListingTypeID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        Parent = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Ordering = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryListingTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        ListingTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.ListingTypes", t => t.ListingTypeID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.ListingTypeID);
            
            CreateTable(
                "dbo.ListingTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ButtonLabel = c.String(nullable: false, maxLength: 20),
                        PriceEnabled = c.Boolean(nullable: false),
                        PriceUnitLabel = c.String(maxLength: 20),
                        OrderTypeID = c.Int(nullable: false),
                        OrderTypeLabel = c.String(maxLength: 20),
                        PaymentEnabled = c.Boolean(nullable: false),
                        ShippingEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryStats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.MetaCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        FieldID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.MetaFields", t => t.FieldID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.FieldID);
            
            CreateTable(
                "dbo.MetaFields",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Placeholder = c.String(maxLength: 255),
                        ControlTypeID = c.Int(nullable: false),
                        Options = c.String(),
                        Required = c.Boolean(nullable: false),
                        Searchable = c.Boolean(nullable: false),
                        Ordering = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ListingMeta",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ListingID = c.Int(nullable: false),
                        FieldID = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Listings", t => t.ListingID, cascadeDelete: true)
                .ForeignKey("dbo.MetaFields", t => t.FieldID, cascadeDelete: true)
                .Index(t => t.ListingID)
                .Index(t => t.FieldID);
            
            CreateTable(
                "dbo.ListingPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ListingID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                        Ordering = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Listings", t => t.ListingID, cascadeDelete: true)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: true)
                .Index(t => t.ListingID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MimeType = c.String(nullable: false, maxLength: 40),
                        SeoFilename = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ListingStats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountView = c.Int(nullable: false),
                        CountSpam = c.Int(nullable: false),
                        CountRepeated = c.Int(nullable: false),
                        ListingID = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Listings", t => t.ListingID, cascadeDelete: true)
                .Index(t => t.ListingID);
            
            CreateTable(
                "dbo.MessageThread",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(maxLength: 200),
                        ListingID = c.Int(),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Listings", t => t.ListingID)
                .Index(t => t.ListingID);
            
            CreateTable(
                "dbo.MessageParticipant",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MessageThreadID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.MessageThread", t => t.MessageThreadID)
                .Index(t => t.MessageThreadID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MessageThreadID = c.Int(nullable: false),
                        Body = c.String(nullable: false),
                        UserFrom = c.String(nullable: false, maxLength: 128),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserFrom, cascadeDelete: true)
                .ForeignKey("dbo.MessageThread", t => t.MessageThreadID)
                .Index(t => t.MessageThreadID)
                .Index(t => t.UserFrom);
            
            CreateTable(
                "dbo.MessageReadState",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MessageID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                        ReadDate = c.DateTime(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Message", t => t.MessageID)
                .Index(t => t.MessageID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        ListingID = c.Int(nullable: false),
                        ListingTypeID = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Quantity = c.Double(),
                        Price = c.Double(),
                        Currency = c.String(maxLength: 3, fixedLength: true),
                        ApplicationFee = c.Double(),
                        Description = c.String(),
                        Message = c.String(),
                        UserProvider = c.String(nullable: false, maxLength: 128),
                        UserReceiver = c.String(nullable: false, maxLength: 128),
                        PaymentPlugin = c.String(maxLength: 250),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserProvider)
                .ForeignKey("dbo.AspNetUsers", t => t.UserReceiver)
                .ForeignKey("dbo.Listings", t => t.ListingID)
                .Index(t => t.ListingID)
                .Index(t => t.UserProvider)
                .Index(t => t.UserReceiver);
            
            CreateTable(
                "dbo.ContentPages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Slug = c.String(nullable: false, maxLength: 100),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 200),
                        Html = c.String(),
                        Template = c.String(maxLength: 200),
                        Ordering = c.Int(nullable: false),
                        Keywords = c.String(maxLength: 200),
                        UserID = c.String(maxLength: 128),
                        Published = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmailTemplates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Slug = c.String(nullable: false, maxLength: 100),
                        Subject = c.String(nullable: false, maxLength: 100),
                        Body = c.String(nullable: false),
                        SendCopy = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SettingDictionary",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Value = c.String(maxLength: 200),
                        SettingID = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Settings", t => t.SettingID)
                .Index(t => t.SettingID);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Slogan = c.String(nullable: false, maxLength: 255),
                        SearchPlaceHolder = c.String(nullable: false, maxLength: 255),
                        EmailContact = c.String(nullable: false, maxLength: 255),
                        Version = c.String(nullable: false, maxLength: 10),
                        Currency = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        TransactionFeePercent = c.Double(nullable: false),
                        TransactionMinimumSize = c.Double(nullable: false),
                        TransactionMinimumFee = c.Double(nullable: false),
                        SmtpHost = c.String(maxLength: 100),
                        SmtpPort = c.Int(),
                        SmtpUserName = c.String(maxLength: 100),
                        SmtpPassword = c.String(maxLength: 100),
                        SmtpSSL = c.Boolean(nullable: false),
                        EmailAddress = c.String(maxLength: 100),
                        EmailDisplayName = c.String(maxLength: 100),
                        AgreementRequired = c.Boolean(nullable: false),
                        AgreementLabel = c.String(maxLength: 100),
                        AgreementText = c.String(),
                        SignupText = c.String(),
                        EmailConfirmedRequired = c.Boolean(nullable: false),
                        Theme = c.String(nullable: false, maxLength: 250),
                        DateFormat = c.String(nullable: false, maxLength: 10),
                        TimeFormat = c.String(nullable: false, maxLength: 10),
                        ListingReviewEnabled = c.Boolean(nullable: false),
                        ListingReviewMaxPerDay = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StripeConnect",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 128),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        token_type = c.String(nullable: false, maxLength: 100),
                        stripe_publishable_key = c.String(nullable: false, maxLength: 100),
                        scope = c.String(nullable: false, maxLength: 100),
                        livemode = c.String(nullable: false, maxLength: 100),
                        stripe_user_id = c.String(nullable: false, maxLength: 100),
                        refresh_token = c.String(nullable: false, maxLength: 100),
                        access_token = c.String(nullable: false, maxLength: 100),
                        error = c.String(maxLength: 100),
                        error_description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StripeTransaction",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ChargeID = c.String(nullable: false, maxLength: 100),
                        StripeToken = c.String(nullable: false, maxLength: 100),
                        StripeEmail = c.String(nullable: false, maxLength: 100),
                        IsCaptured = c.Boolean(nullable: false),
                        FailureCode = c.String(maxLength: 100),
                        FailureMessage = c.String(maxLength: 200),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SettingDictionary", "SettingID", "dbo.Settings");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ListingReviews", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.ListingReviews", "ListingID", "dbo.Listings");
            DropForeignKey("dbo.Orders", "ListingID", "dbo.Listings");
            DropForeignKey("dbo.Orders", "UserReceiver", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "UserProvider", "dbo.AspNetUsers");
            DropForeignKey("dbo.Message", "MessageThreadID", "dbo.MessageThread");
            DropForeignKey("dbo.MessageReadState", "MessageID", "dbo.Message");
            DropForeignKey("dbo.MessageReadState", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Message", "UserFrom", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageParticipant", "MessageThreadID", "dbo.MessageThread");
            DropForeignKey("dbo.MessageParticipant", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageThread", "ListingID", "dbo.Listings");
            DropForeignKey("dbo.Listings", "ListingTypeID", "dbo.ListingTypes");
            DropForeignKey("dbo.ListingStats", "ListingID", "dbo.Listings");
            DropForeignKey("dbo.ListingPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.ListingPictures", "ListingID", "dbo.Listings");
            DropForeignKey("dbo.Listings", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.MetaCategories", "FieldID", "dbo.MetaFields");
            DropForeignKey("dbo.ListingMeta", "FieldID", "dbo.MetaFields");
            DropForeignKey("dbo.ListingMeta", "ListingID", "dbo.Listings");
            DropForeignKey("dbo.MetaCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.CategoryStats", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.CategoryListingTypes", "ListingTypeID", "dbo.ListingTypes");
            DropForeignKey("dbo.CategoryListingTypes", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Listings", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ListingReviews", "UserTo", "dbo.AspNetUsers");
            DropForeignKey("dbo.ListingReviews", "UserFrom", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.SettingDictionary", new[] { "SettingID" });
            DropIndex("dbo.Orders", new[] { "UserReceiver" });
            DropIndex("dbo.Orders", new[] { "UserProvider" });
            DropIndex("dbo.Orders", new[] { "ListingID" });
            DropIndex("dbo.MessageReadState", new[] { "UserID" });
            DropIndex("dbo.MessageReadState", new[] { "MessageID" });
            DropIndex("dbo.Message", new[] { "UserFrom" });
            DropIndex("dbo.Message", new[] { "MessageThreadID" });
            DropIndex("dbo.MessageParticipant", new[] { "UserID" });
            DropIndex("dbo.MessageParticipant", new[] { "MessageThreadID" });
            DropIndex("dbo.MessageThread", new[] { "ListingID" });
            DropIndex("dbo.ListingStats", new[] { "ListingID" });
            DropIndex("dbo.ListingPictures", new[] { "PictureID" });
            DropIndex("dbo.ListingPictures", new[] { "ListingID" });
            DropIndex("dbo.ListingMeta", new[] { "FieldID" });
            DropIndex("dbo.ListingMeta", new[] { "ListingID" });
            DropIndex("dbo.MetaCategories", new[] { "FieldID" });
            DropIndex("dbo.MetaCategories", new[] { "CategoryID" });
            DropIndex("dbo.CategoryStats", new[] { "CategoryID" });
            DropIndex("dbo.CategoryListingTypes", new[] { "ListingTypeID" });
            DropIndex("dbo.CategoryListingTypes", new[] { "CategoryID" });
            DropIndex("dbo.Listings", new[] { "UserID" });
            DropIndex("dbo.Listings", new[] { "ListingTypeID" });
            DropIndex("dbo.Listings", new[] { "CategoryID" });
            DropIndex("dbo.ListingReviews", new[] { "UserTo" });
            DropIndex("dbo.ListingReviews", new[] { "UserFrom" });
            DropIndex("dbo.ListingReviews", new[] { "OrderID" });
            DropIndex("dbo.ListingReviews", new[] { "ListingID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.StripeTransaction");
            DropTable("dbo.StripeConnect");
            DropTable("dbo.Settings");
            DropTable("dbo.SettingDictionary");
            DropTable("dbo.EmailTemplates");
            DropTable("dbo.ContentPages");
            DropTable("dbo.Orders");
            DropTable("dbo.MessageReadState");
            DropTable("dbo.Message");
            DropTable("dbo.MessageParticipant");
            DropTable("dbo.MessageThread");
            DropTable("dbo.ListingStats");
            DropTable("dbo.Pictures");
            DropTable("dbo.ListingPictures");
            DropTable("dbo.ListingMeta");
            DropTable("dbo.MetaFields");
            DropTable("dbo.MetaCategories");
            DropTable("dbo.CategoryStats");
            DropTable("dbo.ListingTypes");
            DropTable("dbo.CategoryListingTypes");
            DropTable("dbo.Categories");
            DropTable("dbo.Listings");
            DropTable("dbo.ListingReviews");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}
