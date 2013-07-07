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
<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th><th>Complex</th></tr>
<tr><th>No</th><td>86</td><td>82</td><td>88</td><td>106</td></tr>
<tr><th>AutoFac 3.0.2</th><td>1067</td><td>1805</td><td>4000</td><td>10568</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>434</td><td>397</td><td>1016</td><td>4035</td></tr>
<tr><th>Catel 3.6</th><td>280</td><td>1568</td><td>3847</td><td>10536</td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>93</td><td>101</td><td>155</td><td>425</td></tr>
<tr><th>fFastInjector 0.8.1</th><td>100</td><td>98</td><td>166</td><td>239</td></tr>
<tr><th>Funq 1.0.0.0</th><td>3629</td><td>3644</td><td>3777</td><td>4337</td></tr>
<tr><th>Griffin 1.1.0</th><td>257</td><td>240</td><td>593</td><td>1489</td></tr>
<tr><th>HaveBox 1.3.0</th><th>79</th><th>95</th><th>101</th><td>137</td></tr>
<tr><th>Hiro 1.0.3</th><td>125</td><td>120</td><td>127</td><td>174</td></tr>
<tr><th>LightCore 1.5.1</th><td>478</td><td>3065</td><td>20028</td><td>101398</td></tr>
<tr><th>LightInject 3.0.0.6</th><td>244</td><td>258</td><td>399</td><td>956</td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>3625</td><td>16961</td><td>41974</td><td>113244</td></tr>
<tr><th>Mef 4.0.0.0</th><td>31016</td><td>35765</td><td>58858</td><td>115428</td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>232</td><td>696</td><td>2156</td><td>5936</td></tr>
<tr><th>Mugen 3.5.1</th><td>639</td><td>690</td><td>1765</td><td>6773</td></tr>
<tr><th>Munq 3.1.6</th><td>123</td><td>151</td><td>426</td><td>1370</td></tr>
<tr><th>Ninject 3.0.1.10</th><td>8097</td><td>16103</td><td>44454</td><td>122686</td></tr>
<tr><th>Petite 0.3.2</th><td>4301</td><td>4237</td><td>6040</td><td>8245</td></tr>
<tr><th>SimpleInjector 2.3.0</th><td>119</td><td>105</td><td>119</td><th>135</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>1329</td><td>13931</td><td>33415</td><td>86183</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1903</td><td>1876</td><td>5326</td><td>14486</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>432</td><td>390</td><td>506</td><td>829</td></tr>
<tr><th>TinyIOC 1.2</th><td>465</td><td>2199</td><td>7996</td><td>30207</td></tr>
<tr><th>Unity 3.0.1304.0</th><td>3177</td><td>4252</td><td>12002</td><td>35685</td></tr>
<tr><th>Windsor 3.2.0</th><td>701</td><td>2384</td><td>6577</td><td>16931</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Generics</th><th>Multiple</th><th>Conditional</th><th>Interception</th></tr>
<tr><th>No</th><td></td><td></td><td></td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>3185</td><td>9564</td><td></td><th>29617</th></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td></td><td>4186</td><td></td><td></td></tr>
<tr><th>Catel 3.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>HaveBox 1.3.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td></td><td></td><td></td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>12547</td><td>30291</td><td></td><td></td></tr>
<tr><th>LightInject 3.0.0.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>136437</td><td>92400</td><td></td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>6189</td><td>5570</td><td>2763</td><td>43426</td></tr>
<tr><th>Munq 3.1.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>50243</td><td>101550</td><td>70614</td><td>55923</td></tr>
<tr><th>Petite 0.3.2</th><td></td><td></td><td></td><td></td></tr>
<tr><th>SimpleInjector 2.3.0</th><th>101</th><th>269</th><td></td><td>30337</td></tr>
<tr><th>Spring.NET 1.3.2</th><td></td><td></td><td></td><td></td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>4100</td><td>17769</td><td></td><td>35635</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>983</td><td>2320</td><th>1969</th><td></td></tr>
<tr><th>TinyIOC 1.2</th><td>10487</td><td></td><td></td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td></td><td>59899</td><td></td><td>129121</td></tr>
<tr><th>Windsor 3.2.0</th><td>5658</td><td>18409</td><td></td><td>45501</td></tr>
</table>
