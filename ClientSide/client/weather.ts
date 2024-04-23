import * as alt from 'alt-client';
import * as native from 'natives';

alt.onServer('setWeather', setWeather);

let oldWeather = 'CLEAR';
let currentWeather = 'CLEAR';

const GtaWeatherList = [
    'EXTRASUNNY',
    'CLEAR',
    'CLOUDS',
    'SMOG',
    'FOGGY',
    'OVERCAST',
    'RAIN',
    'THUNDER',
    'CLEARING',
    'BLIZZARD',
    'SNOWLIGHT',
    'XMAS',
    'NEUTRAL',
    'HALLOWEEN',
];

function setWeather(weather: number, time: number) {
    currentWeather = GtaWeatherList[weather];
    alt.log('wetter: ' + currentWeather);
    if (time === 0) {
        native.setWeatherTypeNow(currentWeather);
    } else {
        if (oldWeather != currentWeather) {
            let i = 0;
            let inter = alt.setInterval(() => {
                i++;
                if (i < 100) {
                    native.setCurrWeatherState(
                        native.getHashKey(oldWeather),
                        native.getHashKey(currentWeather),
                        i / 100
                    );
                } else {
                    alt.clearInterval(inter);
                    oldWeather = currentWeather;
                }
            }, time * 10);
        }
        if (currentWeather === 'XMAS') {
            native.useSnowWheelVfxWhenUnsheltered(true);
            native.useSnowFootVfxWhenUnsheltered(true);
        } else {
            native.useSnowWheelVfxWhenUnsheltered(false);
            native.useSnowFootVfxWhenUnsheltered(false);
        }
    }
}
