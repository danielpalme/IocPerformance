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
<tr><th>No</th><td>93</td><td>89</td><td>92</td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>1087</td><td>1862</td><td>5098</td><td>32953</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>224</td><td>255</td><td>627</td><td></td></tr>
<tr><th>Catel 3.5</th><td>311</td><td>1047</td><td>2967</td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>92</td><td>98</td><td>165</td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><th>82</th><td>106</td><td>144</td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>3686</td><td>4950</td><td>3622</td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td>214</td><td>214</td><td>447</td><td></td></tr>
<tr><th>HaveBox 1.3.0</th><td>87</td><td>103</td><th>94</th><td></td></tr>
<tr><th>Hiro 1.0.3</th><td>135</td><td>128</td><td>148</td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>320</td><td>2950</td><td>13780</td><td></td></tr>
<tr><th>LightInject 3.0.0.6</th><td>182</td><td>177</td><td>287</td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>5623</td><td>19323</td><td>50488</td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>30071</td><td>35334</td><td>58603</td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>231</td><td>510</td><td>1874</td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>489</td><td>602</td><td>1551</td><td></td></tr>
<tr><th>Munq 3.1.6</th><td>98</td><td>115</td><td>415</td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>9293</td><td>20855</td><td>55853</td><td>25316</td></tr>
<tr><th>Petite 0.3.2</th><td>4270</td><td>4283</td><td>4520</td><td></td></tr>
<tr><th>SimpleInjector 2.2.3</th><td>83</td><th>90</th><td>120</td><th>420</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>1635</td><td>14984</td><td>36561</td><td>665</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1462</td><td>1664</td><td>4891</td><td>7734</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>364</td><td>391</td><td>509</td><td></td></tr>
<tr><th>TinyIOC 1.2</th><td>532</td><td>2199</td><td>8132</td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>2648</td><td>3988</td><td>11406</td><td>110373</td></tr>
<tr><th>Windsor 3.2.0</th><td>900</td><td>2543</td><td>7418</td><td>17305</td></tr>
</table>
