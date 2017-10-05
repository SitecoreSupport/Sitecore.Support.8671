using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.ContentSearch.Security;
using Sitecore.ContentSearch.SolrProvider;
using Sitecore.ContentSearch.SolrProvider.SolrOperations;

namespace Sitecore.Support.XA.Foundation.Search.Providers.Solr
{
  public class SwitchOnRebuildSolrCloudSearchIndex : Sitecore.ContentSearch.SolrProvider.SwitchOnRebuildSolrCloudSearchIndex
  {
    public SwitchOnRebuildSolrCloudSearchIndex(string name, string mainalias, string rebuildalias, string activecollection, string rebuildcollection, ISolrOperationsFactory solrOperationsFactory, IIndexPropertyStore propertyStore) : base(name, mainalias, rebuildalias, activecollection, rebuildcollection, solrOperationsFactory, propertyStore)
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