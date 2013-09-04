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
<tr><th>No</th><td>60</td><td>69</td><td>68</td><td>81</td></tr>
<tr><th>SimpleInjector 2.3.5 (http://simpleinjector.codeplex.com)</th><th>80</th><th>84</th><th>100</th><th>123</th></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Interception</th></tr>
<tr><th>No</th><td>86</td><td>68</td><td>145</td><td>119</td><td></td></tr>
<tr><th>SimpleInjector 2.3.5 (http://simpleinjector.codeplex.com)</th><th>162</th><th>87</th><th>202</th><th>307</th><th>4397</th></tr>
</table>
