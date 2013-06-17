Ioc Performance
===============

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](http://www.palmmedia.de)  
Twitter: [@danielpalme](http://twitter.com/danielpalme)  

Results
-------
<table>
<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th><th>Interception</th></tr>
<tr><th>No</th><td>88</td><td>93</td><td>91</td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>1061</td><td>1904</td><td>4918</td><td>33944</td></tr>
<tr><th>Caliburn.Micro 1.5.1</th><td>179</td><td>211</td><td>580</td><td></td></tr>
<tr><th>Catel 3.5</th><td>313</td><td>1140</td><td>3089</td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>88</td><td>110</td><td>166</td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><th>76</th><td>99</td><td>137</td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>3445</td><td>3461</td><td>4843</td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td>194</td><td>218</td><td>487</td><td></td></tr>
<tr><th>HaveBox 1.2.0</th><td>84</td><td>104</td><td>112</td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td>94</td><td>95</td><th>103</th><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>345</td><td>2712</td><td>14608</td><td></td></tr>
<tr><th>LightInject 3.0.0.5</th><td>168</td><td>168</td><td>292</td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>4880</td><td>18770</td><td>49614</td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>33123</td><td>40513</td><td>65587</td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>267</td><td>668</td><td>2299</td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>413</td><td>543</td><td>1440</td><td></td></tr>
<tr><th>Munq 3.1.6</th><td>89</td><td>110</td><td>405</td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>9240</td><td>19205</td><td>54135</td><td></td></tr>
<tr><th>Petite 0.3.2</th><td>4766</td><td>4370</td><td>4554</td><td></td></tr>
<tr><th>SimpleInjector 2.2.3</th><td>83</td><th>88</th><td>107</td><th>504</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>1753</td><td>15647</td><td>37344</td><td>711</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1312</td><td>1361</td><td>4600</td><td>7329</td></tr>
<tr><th>StyleMVVM 3.0.0</th><td>335</td><td>325</td><td>497</td><td></td></tr>
<tr><th>TinyIOC 1.2</th><td>405</td><td>1680</td><td>6233</td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>2563</td><td>3762</td><td>10782</td><td>109092</td></tr>
<tr><th>Windsor 3.2.0</th><td>1030</td><td>2817</td><td>8223</td><td>19275</td></tr>
</table>
