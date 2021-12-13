using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Globalization;
using Microsoft.VisualBasic;

namespace AlienApi.Models {
  public class Alien{
    public int AlienId { get; set; }
    public string Name {get;set;}
    public string Description {get;set;}
    public string OriginPlanet {get;set;}
    public string OriginSystem {get;set;}
    public int NumberOfPlanets {get; set;}
    public bool? BreathesOxygen {get;set;}
    public string KardashevRating {get;set;}

  }
}