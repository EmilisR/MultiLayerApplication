// <auto-generated />
namespace DatabaseLayer.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class UniqueEmail : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(UniqueEmail));
        
        string IMigrationMetadata.Id
        {
            get { return "201711261156063_uniqueEmail"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
