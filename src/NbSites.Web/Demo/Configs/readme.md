# 使用Options模式


使用时注入的几种场景

- IOptionsSnapshot<FooOptions>
- IOptions<FooOptions>
- IConfiguration
- FooOptions

其中IOptions<FooOptions>时，appSettings.json的改变，不会立刻发生变化

