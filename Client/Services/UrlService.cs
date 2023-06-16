using Microsoft.Extensions.Options;
using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Client.Models.Options;

namespace UnitedSystemsCooperative.Web.Client.Services;

public class UrlService
{
    private readonly UscLink[] _uscLinks;
    
    public UrlService(IOptions<LinkOptions> linkOptions)
    {
        _uscLinks = linkOptions.Value.UscLinks;
    }

    /// <summary>
    /// Replaces any bracketed usc keys in a link field
    ///
    /// example: `{discord}`
    /// </summary>
    /// <param name="linkItems">Items to review and replace</param>
    /// <typeparam name="T">Must have a Link field to satisfy ILink</typeparam>
    /// <returns></returns>
    public IEnumerable<T> ReplaceUscUrls<T>(IEnumerable<T> linkItems) where T : ILink
    {
        return linkItems.Select(x =>
        {
            if (!x.Link.Contains('{')) return x;
            var replacement = _uscLinks.First(y =>
                string.Equals(y.Replace, x.Link, StringComparison.CurrentCultureIgnoreCase));
            x.Link = replacement.Link;
            return x;
        });
    }

    public string GetUscLinkByKey(string key) =>
        _uscLinks.FirstOrDefault(x => string.Equals(x.Title, key, StringComparison.OrdinalIgnoreCase))?.Link ??
        string.Empty;
}