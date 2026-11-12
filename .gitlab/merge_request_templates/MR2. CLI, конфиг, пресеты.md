## Что сделано

<!-- Пара предложений своими словами: что появилось в проекте и почему так. -->

## Требования MR2

Параметры из трёх источников с приоритетом: **CLI → JSON-конфиг → дефолты**.

```text
dotnet run -- --seed 32 --iterations 5000 --functions swirl:1.0,horseshoe:0.8 --threads 1 --output result.png
dotnet run -- --config config.json
```

- [ ] CLI-параметры: `--width`, `--height`, `--iterations`, `--output`,
      `--threads`, `--seed`, `--functions`, `--affine-params`, `--config`,
      `--preset`, `--palette`
- [ ] **Пресеты настроения**: `chill`, `energy`, `focus`, `party` —
      задают набор трансформаций, палитру, итерации, размеры
- [ ] **Палитры**: `warm`, `cold`, `neon`, `pastel`, `mono`
- [ ] Расширенная валидация с понятными ошибками
      (`Error: unknown transformation: spiral`)
- [ ] Логирование прогресса в адекватном количестве —
      без попытки залогировать каждую точку

Дефолты: `1920x1080`, `iterations = 2500`, `threads = 1`, `seed = 5`,
`preset = chill`, `palette = warm`, `output = result.png`.

## Обязательные тесты

С реализованных тестов снят `Skip`:

- [ ] `MoodCover.Tests/Mandatory/Mr2/ConfigTest` — чтение JSON, дефолты,
      приоритет CLI над конфигом
- [ ] `MoodCover.IntegrationTests/Mandatory/Mr2/CliValidationTest` —
      валидация через исполняемый файл

## Общий чеклист

- [ ] Реализованы требования MR
- [ ] Добавлены тесты
- [ ] Обновлён README: список поддерживаемых трансформаций и пресетов
- [ ] Запускается локально, результат воспроизводим по seed
- [ ] `dotnet build` и `dotnet test` проходят локально
- [ ] Нет секретов, локальных путей и IDE-файлов

## Бонусы

- [ ] —