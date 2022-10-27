using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Splatools.Infrastructure.ExternalServices.SplatNet3.Models;

public class ScheduleResponse
{
    [JsonProperty("data")] public Data Data { get; set; }
}

public class Data
{
    [JsonProperty("regularSchedules")] public Schedules RegularSchedules { get; set; }

    [JsonProperty("bankaraSchedules")] public Schedules BankaraSchedules { get; set; }

    [JsonProperty("xSchedules")] public Schedules XSchedules { get; set; }

    [JsonProperty("leagueSchedules")] public Schedules LeagueSchedules { get; set; }

    [JsonProperty("coopGroupingSchedule")] public CoopGroupingSchedule CoopGroupingSchedule { get; set; }

    [JsonProperty("festSchedules")] public Schedules FestSchedules { get; set; }

    [JsonProperty("currentFest")] public object CurrentFest { get; set; }

    [JsonProperty("currentPlayer")] public CurrentPlayer CurrentPlayer { get; set; }

    [JsonProperty("vsStages")] public VsStages VsStages { get; set; }
}

public class Schedules
{
    [JsonProperty("nodes")] public List<BankaraSchedulesNode> Nodes { get; set; }
}

public class BankaraSchedulesNode
{
    [JsonProperty("startTime")] public DateTimeOffset StartTime { get; set; }

    [JsonProperty("endTime")] public DateTimeOffset EndTime { get; set; }

    [JsonProperty("bankaraMatchSettings", NullValueHandling = NullValueHandling.Ignore)]
    public List<MatchSetting> BankaraMatchSettings { get; set; }

    [JsonProperty("festMatchSetting")] public object FestMatchSetting { get; set; }

    [JsonProperty("leagueMatchSetting", NullValueHandling = NullValueHandling.Ignore)]
    public MatchSetting LeagueMatchSetting { get; set; }

    [JsonProperty("regularMatchSetting", NullValueHandling = NullValueHandling.Ignore)]
    public MatchSetting RegularMatchSetting { get; set; }

    [JsonProperty("xMatchSetting", NullValueHandling = NullValueHandling.Ignore)]
    public MatchSetting XMatchSetting { get; set; }
}

public class MatchSetting
{
    [JsonProperty("__isVsSetting")] public string IsVsSetting { get; set; }

    [JsonProperty("__typename")] public string Typename { get; set; }

    [JsonProperty("vsStages")] public List<VsStage> VsStages { get; set; }

    [JsonProperty("vsRule")] public VsRule VsRule { get; set; }

    [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
    public string? Mode { get; set; }
}

public class VsRule
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("rule")] public string Rule { get; set; }

    [JsonProperty("id")] public string Id { get; set; }
}

public class VsStage
{
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("vsStageId")] public long VsStageId { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("image")] public UserIcon Image { get; set; }
}

public class UserIcon
{
    [JsonProperty("url")] public Uri Url { get; set; }
}

public class CoopGroupingSchedule
{
    [JsonProperty("regularSchedules")] public RegularSchedules RegularSchedules { get; set; }

    [JsonProperty("bigRunSchedules")] public Schedules BigRunSchedules { get; set; }
}

public class RegularSchedules
{
    [JsonProperty("nodes")] public List<PurpleNode> Nodes { get; set; }
}

public class PurpleNode
{
    [JsonProperty("startTime")] public DateTimeOffset StartTime { get; set; }

    [JsonProperty("endTime")] public DateTimeOffset EndTime { get; set; }

    [JsonProperty("setting")] public Setting Setting { get; set; }
}

public class Setting
{
    [JsonProperty("__typename")] public string Typename { get; set; }

    [JsonProperty("coopStage")] public CoopStage CoopStage { get; set; }

    [JsonProperty("weapons")] public List<Weapon> Weapons { get; set; }
}

public class CoopStage
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("coopStageId")] public long CoopStageId { get; set; }

    [JsonProperty("thumbnailImage")] public UserIcon ThumbnailImage { get; set; }

    [JsonProperty("image")] public UserIcon Image { get; set; }

    [JsonProperty("id")] public string Id { get; set; }
}

public class Weapon
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("image")] public UserIcon Image { get; set; }
}

public class CurrentPlayer
{
    [JsonProperty("userIcon")] public UserIcon UserIcon { get; set; }
}

public class VsStages
{
    [JsonProperty("nodes")] public List<VsStagesNode> Nodes { get; set; }
}

public class VsStagesNode
{
    [JsonProperty("stageId")] public long StageId { get; set; }

    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("vsStageId")] public long VsStageId { get; set; }

    [JsonProperty("originalImage")] public UserIcon OriginalImage { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("stats")] public Stats Stats { get; set; }
}

public class Stats
{
    [JsonProperty("winRateAr")] public double? WinRateAr { get; set; }

    [JsonProperty("winRateLf")] public double? WinRateLf { get; set; }

    [JsonProperty("winRateGl")] public double? WinRateGl { get; set; }

    [JsonProperty("winRateCl")] public double? WinRateCl { get; set; }
}
