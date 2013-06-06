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
<tr><th>No</th><td>82</td><td>98</td><td>94</td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>1194</td><td>2073</td><td>5432</td><td>36119</td></tr>
<tr><th>Caliburn.Micro 1.5.1</th><td>281</td><td>316</td><td>801</td><td></td></tr>
<tr><th>Catel 3.5</th><td>358</td><td>1145</td><td>3165</td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>129</td><td>158</td><td>238</td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><th>91</th><td>112</td><td>153</td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>3594</td><td>3581</td><td>4981</td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td>224</td><td>241</td><td>499</td><td></td></tr>
<tr><th>HaveBox 1.0.0</th><td>4033</td><td>3987</td><td>4694</td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td>129</td><td>117</td><td>144</td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>358</td><td>2655</td><td>12976</td><td></td></tr>
<tr><th>LightInject 3.0.0.5</th><td>184</td><td>193</td><td>362</td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>4932</td><td>18897</td><td>48885</td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>30867</td><td>35320</td><td>58878</td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>248</td><td>574</td><td>1970</td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>430</td><td>563</td><td>1498</td><td></td></tr>
<tr><th>Munq 3.1.6</th><td>101</td><td>122</td><td>431</td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>10432</td><td>20599</td><td>59612</td><td></td></tr>
<tr><th>Petite 0.3.2</th><td>5822</td><td>5795</td><td>6124</td><td></td></tr>
<tr><th>SimpleInjector 2.2.3</th><td>94</td><th>104</th><th>118</th><th>455</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>2184</td><td>18656</td><td>44863</td><td>1229</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1924</td><td>1926</td><td>6517</td><td>12224</td></tr>
<tr><th>TinyIOC 1.2</th><td>555</td><td>2309</td><td>8355</td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>3614</td><td>5156</td><td>15091</td><td>117585</td></tr>
<tr><th>Windsor 3.2.0</th><td>1185</td><td>3132</td><td>9559</td><td>18550</td></tr>
</table>
