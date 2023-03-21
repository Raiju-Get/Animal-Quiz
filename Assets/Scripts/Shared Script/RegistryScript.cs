using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Permissions;
using Microsoft.Win32;

public class RegistryScript : MonoBehaviour
{

    DateTime currentDateTime = DateTime.Now;
    [SerializeField] string tempData;
    public bool isLocked;
    public bool hasWrittin;
    private void Awake()
    {
        try
        {
            tempData = GetCurrentDataChimpvine("ExpTime");
            DateTime checkTime = DateTime.Parse(tempData);
            UnityEngine.Debug.Log(checkTime + ":License date");
            UnityEngine.Debug.Log(currentDateTime + ":Current date");
            if (checkTime <= currentDateTime)
            {
                UnityEngine.Debug.Log("Locked");
                isLocked = true;
                SaveSystem.SaveData(isLocked);
            }
            else
            {
                UnityEngine.Debug.Log("Unlocked");
                isLocked = false;
            }
        }
        catch
        {
            WriteData(currentDateTime);
            UnityEngine.Debug.Log(tempData + "Writing");

        }

        try
        {
            hasWrittin = SaveSystem.LoadData();
        }
        catch
        {
            SaveSystem.SaveData(isLocked);

        }



    }

    public string GetCurrentData(string value)
    {
        RegistryKey key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\BIOS");
        return key.GetValue(value).ToString();
    }

    public string GetCurrentDataChimpvine(string value)
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Chimpvine");

        return key.GetValue(value).ToString();
    }

    public void WriteData(DateTime currentDateTime)
    {
        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Chimpvine");
        DateTime licenseDate = new DateTime(2024, 02, 01, 01, 00, 00);
        key.SetValue("ExpTime", licenseDate);
        key.Close();
    }

    public void AddYearData()
    {
        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Chimpvine");
        DateTime licenseDate = currentDateTime.AddYears(1);
        key.SetValue("ExpTime", licenseDate);
        key.Close();
    }
    public void AddMonthData()
    {
        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Chimpvine");
        DateTime licenseDate = currentDateTime.AddDays(30);
        key.SetValue("ExpTime", licenseDate);
        key.Close();

    }
    public void AddWeekData()
    {
        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Chimpvine");
        DateTime licenseDate = currentDateTime.AddDays(7);
        key.SetValue("ExpTime", licenseDate);
        key.Close();
    }
    public void AddMinutesData()
    {
        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Chimpvine");
        DateTime licenseDate = currentDateTime.AddMinutes(10);
        key.SetValue("ExpTime", licenseDate);
        key.Close();
    }
    public void AddMinuteData()
    {
        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Chimpvine");
        DateTime licenseDate = currentDateTime.AddMinutes(1);
        key.SetValue("ExpTime", licenseDate);
        key.Close();
    }

}


