using Boc.ExamOnline.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Boc.ExamOnline.Permissions;

public class ExamOnlinePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ExamOnlinePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ExamOnlinePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ExamOnlineResource>(name);
    }
}
