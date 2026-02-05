using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : Singleton<GameSettings>
{
    [SerializeField] private GeneralSettingsSO _generalSettingsSO;

    public GeneralSettingsSO GetGeneralSettings => _generalSettingsSO;
}