using Core.Models.User;
using Web.Components.User;
using Web.ViewModels.User.Components;

namespace Web.Test.Unit.Components;

[TestClass]
public class TestEquipmentViewComponent
{
    [TestMethod]
    public async Task GetUserEquipmentStatus_WhenUserHasNoEquipment_ReturnsNoEquipmentStatus()
    {
    }

    [TestMethod]
    public async Task GetUserEquipmentStatus_WhenUserHasSomeEquipment_ReturnsPartialEquipmentStatus()
    {
    }

    [TestMethod]
    public async Task GetUserEquipmentStatus_WhenUserHasEquipment_ReturnsEquipmentStatus()
    {
    }

    [TestMethod]
    public async Task GetUserEquipmentStatus_WhenUserHasNoEquipmentAndIsOnlyMobility_ReturnsNoEquipmentStatus()
    {
    }
}
