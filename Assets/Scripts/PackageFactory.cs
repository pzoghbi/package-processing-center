using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PackageFactory : MonoBehaviour {
    public Package packagePrefab;
    public List<PackageType> packageTypes;

    public Package CreatePackage(Item item) {
        var pkg = Instantiate(packagePrefab);
        pkg.weight = item.data.weight;
        var ptype = packageTypes.First(pt => pt.type == item.type);
        pkg.sprite = ptype.sprite;
        
        return pkg;
    }

    public PackageType GetPackageType(Item item) {
        var ptype = packageTypes.First(pt => pt.type == item.type);
        return ptype;
    }
    
    public static PackageFactory Instance { get; private set; }
    
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
            return;
        }
    }
}

[Serializable]
public class PackageType {
    public int type;
    public Sprite sprite;
}
