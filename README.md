# Essential Vision preprocessing pipeline

Application to preprocess animated 3D medical data for Essential Vision application. See the [official webpage of Essential Vision](https://www.essential-vision.org/) for more detailed list of features and demo videos.

## Compatible models

      * You can import models as a series of VTK models. The [input format specification is here](https://github.com/MicroscopeIT/holo-preprocess/tree/master/Input%20documentation). Example VTK model is inside `Test Model` subdirectory there. This is the advised format, that supports animation using blend shapes.

      * Or you can import models with each layer loaded from Unity assets (so it can be .obj, .prefab or any other model format supported by Unity). Example is inside `EVPreprocessing/Assets/Test Models/Skull/` in this repository.

#### Converting VTK model series into Asset Bundles

**In Unity GUI**
Open Unity project from unity/EVPreprocessing.

1. Run script: **EVPreprocessing -> Create an AssetBundle from an external supported format**
2. Choose the directory with model time series in VTK files
3. Your resulting AssetBundle is located in _**<repository location>/unity/Holo/Assets/StreamingAssets/<name of converted directory>\_bundle(.manifest)**_

**Through CMD**
1. Run CMD as an administrator
2. Run the following command: 
```
"<Path to Unity.exe>" -quit -batchmode -logFile "<Path to the Unitys logfile>"  -projectPath "<path to the EVPreprocessing project>" -executeMethod DataPreparator.ImportWithConversion --RootDirectory "<Directory of the input's model root folder>" --OutputDir ""<Directory where ABs will be stored" --LogDir "<directory where debug logfiles will be stored>"
```

**Important:** Path to the Unity.exe needs to lead to the 2018.4 version. --OutputDir and --LogDir flags need to be raised, if user wants to leave them at the default paths, one just needs to leave their values empty.
