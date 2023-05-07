using System.ComponentModel;
using Homo.AuthApi;

namespace Homo.FarmApi
{
    public enum STRAWBERRY_DISEASE
    {
        [Description("炭疽")]
        ANTHRACNOSE = 0,
        [Description("缺鈣")]
        CALCIUM_DEFICIENCY = 1,
        [Description("缺鎂")]
        MAGNESIUM_DEFICIENCY = 2,
        [Description("馬薊感染")]
        THISTLE_INFECTION = 3,
        [Description("青枯")]
        BLACK_ROT = 4,
        [Description("紅蜘蛛")]
        RED_SPIDER_MITE_INFECTION = 5,
        [Description("缺氮")]
        NITROGEN_DEFICIENCY = 6,
        [Description("缺鉀")]
        POTASSIUM_DEFICIENCY = 7,
        [Description("缺磷")]
        PHOSPHORUS_DEFICIENCY = 8,
        [Description("缺微量元素")]
        TRACE_ELEMENT_DEFICIENCY = 9,
        [Description("肥傷")]
        FERTILIZER_DAMAGE = 10
    }
}