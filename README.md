Playing around with bitwise operations  
`GameManager.cs`
```cs
// first two bits reserved for box type [1 = small, 2 = medium, 3 = large, 0 = invalid]
if (GetType(idata.weight) == (i.type & 0b11)) { 
    points += 1;
}

// Third bit = Fragile?
var fragValue = (i.type >> 2) & 1;
var realFrag = idata.fragile ? 1 : 0;
if (realFrag != fragValue) {
    points -= 1;
}

// ...
```

#### Dev Log
- Update 1.1.0 - added QoL instructions during gameplay
- Update 1.0.1 - fixed some item configs
- Release 1.0.0

#### Basic info
- Created for Trijam #339 in 3 hours w/ John 'Fervir' who did all the art
- [Play in a web browser on itch.io](https://croatia.itch.io/package-processing-center)

#### Engine info
- Unity 2022.3.62f1
