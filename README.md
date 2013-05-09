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
<tr><th>No</th><td>132</td><td>81</td><td>63</td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>749</td><td>1806</td><td>4570</td><td>33765</td></tr>
<tr><th>Caliburn.Micro 1.5.1</th><td>194</td><td>226</td><td>651</td><td></td></tr>
<tr><th>Catel 3.5</th><td>258</td><td>952</td><td>2846</td><td></td></tr>
<tr><th>Dynamo 3.0.1.0</th><td>72</td><th>84</th><td>139</td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>81</td><td>92</td><td>277</td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td>194</td><td>195</td><td>481</td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td>101</td><td>103</td><td>107</td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>156</td><td>2343</td><td>12045</td><td></td></tr>
<tr><th>LightInject 3.0.0.5</th><td>171</td><td>178</td><td>298</td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>2876</td><td>17564</td><td>47712</td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>2507</td><td>8724</td><td>24937</td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>150</td><td>485</td><td>2019</td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>302</td><td>483</td><td>1404</td><td></td></tr>
<tr><th>Munq 3.1.6</th><td>102</td><td>131</td><td>412</td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>6791</td><td>19314</td><td>54926</td><td></td></tr>
<tr><th>Petite 0.3.2</th><td>86</td><td>86</td><td>260</td><td></td></tr>
<tr><th>SimpleInjector 2.2.3</th><th>68</th><td>87</td><td>101</td><th>467</th></tr>
<tr><th>Speedioc 0.1.33</th><td>96</td><td>109</td><th>94</th><td></td></tr>
<tr><th>Spring.NET 1.3.2</th><td>672</td><td>14560</td><td>39065</td><td>666</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1127</td><td>1213</td><td>4379</td><td>7329</td></tr>
<tr><th>TinyIOC 1.2</th><td>246</td><td>1500</td><td>6098</td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>2451</td><td>3807</td><td>11212</td><td>103682</td></tr>
<tr><th>Windsor 3.2.0</th><td>456</td><td>2422</td><td>6970</td><td>16677</td></tr>
</table>
