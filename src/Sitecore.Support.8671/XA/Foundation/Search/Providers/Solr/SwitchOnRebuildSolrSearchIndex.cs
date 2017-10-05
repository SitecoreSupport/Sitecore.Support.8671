using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.ContentSearch.Security;
using Sitecore.ContentSearch.SolrProvider;

namespace Sitecore.Support.XA.Foundation.Search.Providers.Solr
{
  public class SwitchOnRebuildSolrSearchIndex : Sitecore.ContentSearch.SolrProvider.SwitchOnRebuildSolrSearchIndex
  {
    public SwitchOnRebuildSolrSearchIndex(string name, string core, string rebuildcore, IIndexPropertyStore propertyStore) : base(name, core, rebuildcore, propertyStore)
    {
    }

    public override void Initialize()
    {
      base.Initialize();
      this.FieldNameTranslator = new SolrFieldNameTranslator(this);
    }

    public override IProviderSearchContext CreateSearchContext(SearchSecurityOptions options = 0)
    {
      if (this.Group == IndexGroup.Experience)
      {
        return new SolrAnalyticsSearchContext(this, options);
      }
      return new SolrSearchContext(this, options);
    }
  }
}
