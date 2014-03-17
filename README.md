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
<tr><th>No</th><td>81</td><td>94</td><td>96</td><td>108</td></tr>
<tr><th>LightInject 3.0.1.6 (https://github.com/seesharper/LightInject)</th><th>56</th><th>55</th><th>62</th><th>117</th></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th></tr>
<tr><th>No</th><td>118</td><td>91</td><td>226</td><td>165</td>
<tr><th>LightInject 3.0.1.6 (https://github.com/seesharper/LightInject)</th><th>100</th><th>59</th><th>325</th><th>138</th>
</table>
Additional Advanced Features
<table>
<tr><th>Container</th><th>Child Container</th><th>Interception</th></tr>
<tr><th>No</th><td>300</td><td>119</td>
<tr><th>LightInject 3.0.1.6 (https://github.com/seesharper/LightInject)</th><th></th><th>1204</th>
</table>
