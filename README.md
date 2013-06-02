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
<tr><th>No</th><td>116</td><td>79</td><td>67</td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>688</td><td>1738</td><td>4948</td><td>36320</td></tr>
<tr><th>Caliburn.Micro 1.5.1</th><td>177</td><td>210</td><td>603</td><td></td></tr>
<tr><th>Catel 3.5</th><td>282</td><td>1127</td><td>3238</td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>78</td><td>88</td><td>149</td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><th>26</th><th>55</th><th>89</th><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>77</td><td>92</td><td>252</td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td>191</td><td>203</td><td>556</td><td></td></tr>
<tr><th>HaveBox 1.0.0</th><td>53</td><td>102</td><td>215</td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td>114</td><td>116</td><td>119</td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>167</td><td>3089</td><td>15419</td><td></td></tr>
<tr><th>LightInject 3.0.0.5</th><td>184</td><td>172</td><td>309</td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>2959</td><td>18677</td><td>51308</td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>2790</td><td>11383</td><td>32373</td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>169</td><td>725</td><td>2081</td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>305</td><td>487</td><td>1381</td><td></td></tr>
<tr><th>Munq 3.1.6</th><td>101</td><td>129</td><td>460</td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>7181</td><td>19873</td><td>56288</td><td></td></tr>
<tr><th>Petite 0.3.2</th><td>91</td><td>94</td><td>274</td><td></td></tr>
<tr><th>SimpleInjector 2.2.3</th><td>70</td><td>84</td><td>103</td><th>547</th></tr>
<tr><th>Speedioc 0.1.33</th><td>122</td><td>85</td><td>102</td><td></td></tr>
<tr><th>Spring.NET 1.3.2</th><td>663</td><td>15126</td><td>39873</td><td>695</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1206</td><td>1252</td><td>4249</td><td>7889</td></tr>
<tr><th>TinyIOC 1.2</th><td>287</td><td>1913</td><td>7081</td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>2448</td><td>3786</td><td>14184</td><td>111708</td></tr>
<tr><th>Windsor 3.2.0</th><td>568</td><td>5469</td><td>9731</td><td>19083</td></tr>
</table>
