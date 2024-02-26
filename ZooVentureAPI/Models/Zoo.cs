using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZooVentureAPI.Models
{
    [XmlRoot("Zoo")]
    public class Zoo
    {
        [XmlElement("Lions")]
        public LionList Lions { get; set; }

        [XmlElement("Giraffes")]
        public GiraffeList Giraffes { get; set; }

        [XmlElement("Tigers")]
        public TigerList Tigers { get; set; }

        [XmlElement("Zebras")]
        public ZebraList Zebras { get; set; }

        [XmlElement("Wolves")]
        public WolfList Wolves { get; set; }

        [XmlElement("Piranhas")]
        public PiranhaList Piranhas { get; set; }
    }

    [XmlRoot("Lions")]
    public class LionList
    {
        [XmlElement("Lion")]
        public List<Lion> Lions { get; set; }
    }

    [XmlRoot("Giraffes")]
    public class GiraffeList
    {
        [XmlElement("Giraffe")]
        public List<Giraffe> Giraffes { get; set; }
    }

    [XmlRoot("Tigers")]
    public class TigerList
    {
        [XmlElement("Tiger")]
        public List<Tiger> Tigers { get; set; }
    }

    [XmlRoot("Zebras")]
    public class ZebraList
    {
        [XmlElement("Zebra")]
        public List<Zebra> Zebras { get; set; }
    }

    [XmlRoot("Wolves")]
    public class WolfList
    {
        [XmlElement("Wolf")]
        public List<Wolf> Wolves { get; set; }
    }

    [XmlRoot("Piranhas")]
    public class PiranhaList
    {
        [XmlElement("Piranha")]
        public List<Piranha> Piranhas { get; set; }
    }

    public class Animal
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("kg")]
        public decimal Weight { get; set; }
    }

    public class Lion : Animal { }

    public class Giraffe : Animal { }

    public class Tiger : Animal { }

    public class Zebra : Animal { }

    public class Wolf : Animal { }

    public class Piranha : Animal { }
}
