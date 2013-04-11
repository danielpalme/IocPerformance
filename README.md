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
<tr><th>No</th><td>76</td><td>66</td><td>65</td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>753</td><td>1979</td><td>4628</td><td>36762</td></tr>
<tr><th>Caliburn.Micro 1.5.1</th><td>243</td><td>298</td><td>762</td><td></td></tr>
<tr><th>Catel 3.5</th><td>278</td><td>1042</td><td>2897</td><td></td></tr>
<tr><th>Dynamo 3.0.1.0</th><td>73</td><th>84</th><td>142</td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>77</td><td>93</td><td>249</td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td>192</td><td>203</td><td>499</td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td>102</td><td>105</td><th>110</th><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>164</td><td>2461</td><td>13142</td><td></td></tr>
<tr><th>LightInject 3.0.0.1</th><td>147</td><td>152</td><td>289</td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>2940</td><td>17733</td><td>49750</td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>2685</td><td>10274</td><td>27696</td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>151</td><td>602</td><td>2235</td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>386</td><td>576</td><td>1435</td><td></td></tr>
<tr><th>Munq 3.1.6</th><td>104</td><td>127</td><td>400</td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>7328</td><td>18844</td><td>54933</td><td></td></tr>
<tr><th>Petite 0.3.2</th><td>74</td><td>85</td><td>257</td><td></td></tr>
<tr><th>SimpleInjector 2.2.0</th><td>122</td><td>136</td><td>146</td><th>521</th></tr>
<tr><th>Speedioc 0.1.33</th><th>65</th><td>107</td><td>126</td><td></td></tr>
<tr><th>Spring.NET 1.3.2</th><td>670</td><td>14285</td><td>40429</td><td>783</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1329</td><td>1660</td><td>4771</td><td>7412</td></tr>
<tr><th>TinyIOC 1.2</th><td>240</td><td>1615</td><td>6271</td><td></td></tr>
<tr><th>Unity 2.1.505.2</th><td>2047</td><td>3271</td><td>10566</td><td>103504</td></tr>
<tr><th>Windsor 3.2.0</th><td>667</td><td>2786</td><td>7849</td><td>18427</td></tr>
</table>
