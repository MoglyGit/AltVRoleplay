import * as alt from 'alt-client';
import * as native from 'natives';
import './inventory/typescript.js';
import './login/typescript.js';
import './face/editor.js';
import './TextLabel/3DText.js';
import './Vehicle/veh.js';
import './Vehicle/marquisInterior.js';
import './Vehicle/boattrailer.js';
import './Vehicle/flatbed.js';
import './Hud/time.js';
import './Entity/entity.js';
import './Perso/typescript.js';
import './Licenses/typescript.js';
import './MDC/typescript.js';
import './MousePointer/mouse.js';
import './Bank/typescript.js';
import './CarRegister/typescript.js';
import './Apartment/typescript.js';
import './Notification/notification.js';
import './Sync/sync.js';
import './Sync/BoatAnker.js';
import './Sync/Gurt.js';
import './Sync/VehicleBoost.js';
import './DrivingLicense/typescript.js';
import './Tacho/tacho.js';
import './CarSell/main.js';
import './perioisland.js';
import './weather.js';
import './Checkpoints.js';
import './ConnectionComplete.js';
import './PlayerFriends/Friends.js';
import './WeaponShop/typescript.js';
import './IronFarm/startup.js';
import './Fishing/startup.js';
import './RemoveObjects/startup.js';
import './Factions/Garbage/main.js';
import './Store247/main.js';
import './Store247/main_owned.js';
import './Store247/main_buyitem.js';
import './Dealer/main.js';
import './Gasstation/main.js';
import './GasFill/main.js';
import './Firmen/main.js';
import './Firmen/CarDealer/carDealermain.js';
import './Firmen/CarDealer/carDealerMenuMain.js';
import './Firmen/Konto/main.js';
import './Firmen/Name/main.js';
import './Firmen/Tuner/main.js';
import './Firmen/Mechanic/MechanicMenu.js';
import './Firmen/WorkerList/main.js';
import './InteractionMenu/main.js';
import './InteractionMenuVehicle/main.js';
alt.onServer('blockPlayerInventory', blockPlayerInventory);
alt.onServer('CreateBlip', createBlip);
alt.onServer('ChangeBlipName', changeBlipName);
alt.onServer('log:Console', handleLogConsole);
alt.onServer('playerConnect', OnPlayerConnect);
alt.onServer('sound', PlaySound);
alt.onServer('CreateAppartment', CreateAppartment);
function CreateAppartment(positio, interior, rent, name) {
    let street = native.getStreetNameAtCoord(positio.x, positio.y, positio.z);
    const streetname = native.getStreetNameFromHashKey(street[1]);
    const finalname = name + '\n' + streetname;
    alt.emitServer('CreateAppartment', positio, interior, rent, finalname);
}
function PlaySound(sound, ref) {
    native.playSoundFrontend(-1, sound, ref, true);
}
function blockPlayerInventory(state) {
    if (state) alt.setMeta('noInv', 1);
    else alt.deleteMeta('noInv');
}
function OnPlayerConnect() {
    alt.Player.local.setMeta('allowInv', true);
    loadIpls();
    alt.loadDefaultIpls();
    loadBlip();
    loadVehicleModels();
    const blip = native.getMainPlayerBlipId();
    native.setBlipShowCone(blip, false, 0);
    native.setBlipDisplay(blip, 0);
}
async function loadVehicleModels() {
//await alt.Utils.requestModel(alt.hash('karby'));
}
function handleLogConsole(msg) {
    alt.log(msg);
}
alt.onServer('SetRadar', SetRadar);
function SetRadar(t) {
    native.displayRadar(t);
    if (t) {
        const blip = native.getMainPlayerBlipId();
        native.setBlipShowCone(blip, true, 0);
        native.setBlipDisplay(blip, 2);
        return;
    }
    const blip = native.getMainPlayerBlipId();
    native.setBlipShowCone(blip, false, 0);
    native.setBlipDisplay(blip, 0);
}
alt.onServer('triggerTP', tpToWaypoint);
function tpToWaypoint() {
    var waypoint = native.getFirstBlipInfoId(8);
    if (native.doesBlipExist(waypoint)) {
        let coords = native.getBlipInfoIdCoord(waypoint);
        let groundZ;
        alt.emitServer('doTheTeleport', coords.x, coords.y, 200);
        setTimeout(()=>{
            groundZ = native.getGroundZFor3dCoord(alt.Player.local.pos.x, alt.Player.local.pos.y, alt.Player.local.pos.z, undefined, undefined, undefined);
            alt.emitServer('doTheTeleport', coords.x, coords.y, parseFloat(groundZ[1]) + 0.8);
        }, 2000);
    }
}
function loadBlip() {
    //Colorid 2 = Staat, 5 = Mieten, 25=Fleeca, 3 = MiniJob, 1 =illegal, 47 = ankauf
    //Illegal ankauf
    createBlip(-13.674725, 6480.6064, 31.4198, 280, 47, 1.0, true, 'Relaed');
    createBlip(1701.0857, 4857.587, 42.01831, 280, 47, 1.0, true, 'Relaed');
    createBlip(2.043956, -1225.6088, 29.279907, 280, 47, 1.0, true, 'Relaed');
    //Fish ankauf
    createBlip(1894.0483, 3715.1736, 32.750977, 280, 47, 1.0, true, 'Fishankauf');
    createBlip(-815.6044, -1346.5714, 5.134033, 280, 47, 1.0, true, 'Fishankauf');
    //angel
    createBlip(4863.059, -1769.288, 0.61828613, 317, 3, 1.0, true, 'Delphin gebiet');
    createBlip(-2800.2725, 7648.378, -0.72961426, 317, 3, 1.0, true, 'Delphin gebiet');
    createBlip(-3376.8, -1683.0593, -1.5552979, 317, 3, 1.0, true, 'Hai gebiet');
    createBlip(5660.993, 6806.518, -1.2182617, 317, 3, 1.0, true, 'Hai gebiet');
    createBlip(368.9934, 3969.5078, 30.89746, 317, 3, 1.0, true, 'Tropishes gebiet');
    createBlip(468.87033, -4588.7866, 0.4835205, 317, 3, 1.0, true, 'Tropishes gebiet');
    createBlip(2095.912, 4295.3276, 30.324585, 317, 3, 1.0, true, 'Kugelfish gebiet');
    createBlip(5296.615, 3085.1077, -1.4710693, 317, 3, 1.0, true, 'Kugelfish gebiet');
    createBlip(1205.9736, 2658.0527, 37.80591, 488, 4, 1.0, true, 'Tuning');
    //factions
    createBlip(-355.12088, -1513.7406, 27.712769, 318, 4, 1.0, true, 'Mülldeponie');
    createBlip(51.65275, 6485.987, 31.4198, 318, 4, 1.0, true, 'Mülldeponie');
    //Jobs
    createBlip(-567.9429, 5253.389, 70.47766, 527, 2, 1.0, true, 'Holzfabrik');
    createBlip(2949.7847, 2748.1714, 43.45056, 529, 2, 1.0, true, 'Steinbruch');
    //ankauf
    createBlip(838.83954, 2176.2988, 52.279907, 280, 47, 1.0, true, 'Holzankauf');
    createBlip(-114.843956, -967.12085, 27.27478, 280, 47, 1.0, true, 'Holzankauf');
    createBlip(1724.29, 3696.25, 34.4022, 280, 47, 1.0, true, 'Eisenankauf');
    createBlip(-195.653, 6265.09, 31.4872, 280, 47, 1.0, true, 'Eisenankauf');
    createBlip(-484.95825, -1730.7429, 19.54065, 280, 47, 1.0, true, 'Mineralien Experte');
    createBlip(-331.84616, 6084.8174, 31.453491, 110, 4, 1.0, true, 'Waffen und Mehr');
    createBlip(1692.2902, 3761.1296, 34.6886, 110, 4, 1.0, true, 'Waffen und Mehr');
    createBlip(-1119.0593, 2699.7363, 18.546509, 110, 4, 1.0, true, 'Waffen und Mehr');
    createBlip(-3173.6572, 1088.255, 20.838135, 110, 4, 1.0, true, 'Waffen und Mehr');
    createBlip(-1304.1099, -394.8, 36.693726, 110, 4, 1.0, true, 'Waffen und Mehr');
    createBlip(253.87253, -50.67692, 69.93848, 110, 4, 1.0, true, 'Waffen und Mehr');
    createBlip(-662.2681, -933.4813, 21.81543, 110, 4, 1.0, true, 'Waffen und Mehr');
    createBlip(842.4791, -1035.3231, 28.18457, 110, 4, 1.0, true, 'Waffen und Mehr');
    createBlip(2567.9473, 292.5099, 108.726685, 110, 4, 1.0, true, 'Waffen und Mehr');
    createBlip(1540.0747, 6336.158, 24.073242, 225, 1, 1.0, true, 'Autoankauf');
    createBlip(1219.5165, -3204.633, 5.6226807, 225, 1, 1.0, true, 'Autoankauf');
    createBlip(383.52527, 3562.1143, 33.307007, 225, 1, 1.0, true, 'Autoankauf');
    //Boat
    createBlip(-718.24615, -1343.7495, -0.32531738, 410, 2, 1.0, true, 'Boote');
    //sandy
    createBlip(1361.0901, 3603.6265, 34.941406, 225, 2, 1.0, true, 'Gebrauchtwagen');
    //BlaineCounty
    createBlip(-215.31429, 6218.677, 31.487183, 225, 2, 1.0, true, 'Compacts');
    //Bike
    createBlip(-165.27032, -1432.2858, 31.166992, 225, 2, 1.0, true, 'Motorrad');
    createBlip(-1626.3429, 214.1011, 60.43518, 438, 2, 1.0, true, 'Schule');
    createBlip(-1348.5626, 142.72089, 56.424927, 66, 3, 1.0, true, 'MiniJob');
    createBlip(-138.40878, -257.19562, 43.585327, 66, 3, 1.0, true, 'MiniJob');
    createBlip(247.14725, 225.05934, 106.28357, 374, 13, 1.0, true, 'Bank');
    createBlip(-112.27252, 6471.178, 31.621948, 374, 13, 1.0, true, 'Bank');
    createBlip(313.74066, -280.52307, 54.150146, 374, 25, 1.0, true, 'Fleeca-Bank');
    createBlip(-2961.0857, 482.9934, 15.682007, 374, 25, 1.0, true, 'Fleeca-Bank');
    createBlip(1175.0374, 2708.2944, 38.07544, 374, 25, 1.0, true, 'Fleeca-Bank');
    createBlip(-1212.0527, -332.1099, 37.772217, 374, 25, 1.0, true, 'Fleeca-Bank');
    createBlip(-351.2835, -51.32308, 49.027832, 374, 25, 1.0, true, 'Fleeca-Bank');
    createBlip(149.4989, -1042.1274, 29.364136, 374, 25, 1.0, true, 'Fleeca-Bank');
    createBlip(-67.898895, -205.7011, 45.80957, 326, 37, 1.0, true, 'Fahrschule');
    createBlip(-1091.5253, -2595.1648, 13.811768, 376, 5, 1.0, true, 'E-Rollerverleih');
    createBlip(-1234.7472, -1450.3385, 4.2747803, 376, 5, 1.0, true, 'Fahrradverleih');
    createBlip(-544.65497, -204.81758, 38.210205, 120, 2, 1.0, true, 'Stadthalle');
}
function changeBlipName(x, y, oldname, newname) {
    //const changeBlip = alt.PointBlip.all.find((b) => b.pos.x == x && b.name == oldname);
    alt.PointBlip.all.forEach((b)=>{
        if (b.pos.x == x && b.name == oldname && b.pos.y == y) {
            b.name = newname;
        }
    });
}
function createBlip(x, y, z, sprite, color, scale = 1.0, shortrange = true, name = '') {
    const tempBlip = new alt.PointBlip(x, y, z);
    tempBlip.sprite = sprite;
    tempBlip.color = color;
    tempBlip.scale = scale;
    tempBlip.shortRange = shortrange;
    if (name.length > 0) tempBlip.name = name;
}
function loadIpls() {
    let interrior = native.getInteriorAtCoords(-1350.0, 160.0, -100.0);
    native.refreshInterior(interrior);
    alt.requestIpl('facelobby');
    alt.requestIpl('v_tunnel_hole');
    alt.requestIpl('v_tunnel_hole_lod');
    native.activateInteriorEntitySet(native.getInteriorAtCoordsWithType(-38.62, -1099.01, 27.31, 'v_carshowroom'), 'csr_beforeMission');
    native.activateInteriorEntitySet(native.getInteriorAtCoordsWithType(-38.62, -1099.01, 27.31, 'v_carshowroom'), 'shutter_closed');
    alt.requestIpl('ex_dt1_02_office_02b');
    alt.requestIpl('chop_props');
    alt.requestIpl('FIBlobby');
    alt.removeIpl('FIBlobbyfake');
    alt.requestIpl('FBI_colPLUG');
    alt.requestIpl('FBI_repair');
    alt.requestIpl('v_tunnel_hole');
    alt.requestIpl('TrevorsMP');
    alt.requestIpl('TrevorsTrailer');
    alt.requestIpl('TrevorsTrailerTidy');
    alt.removeIpl('farmint');
    alt.removeIpl('farm_burnt');
    alt.removeIpl('farm_burnt_props');
    alt.removeIpl('des_farmhs_endimap');
    alt.removeIpl('des_farmhs_end_occl');
    alt.requestIpl('farm');
    alt.requestIpl('farm_props');
    alt.requestIpl('farm_int');
    alt.requestIpl('facelobby');
    alt.removeIpl('CS1_02_cf_offmission');
    alt.requestIpl('CS1_02_cf_onmission1');
    alt.requestIpl('CS1_02_cf_onmission2');
    alt.requestIpl('CS1_02_cf_onmission3');
    alt.requestIpl('CS1_02_cf_onmission4');
    alt.requestIpl('v_rockclub');
    alt.requestIpl('v_janitor');
    alt.removeIpl('hei_bi_hw1_13_door');
    alt.requestIpl('bkr_bi_hw1_13_int');
    alt.removeIpl('v_carshowroom');
    alt.removeIpl('shutter_open');
    alt.removeIpl('shutter_closed');
    alt.removeIpl('shr_int');
    alt.requestIpl('csr_afterMission');
    alt.requestIpl('v_carshowroom');
    alt.requestIpl('shr_int');
    alt.requestIpl('shutter_closed');
    alt.requestIpl('smboat');
    alt.requestIpl('smboat_distantlights');
    alt.requestIpl('smboat_lod');
    alt.requestIpl('smboat_lodlights');
    alt.requestIpl('cargoship');
    alt.requestIpl('railing_start');
    alt.removeIpl('sp1_10_fake_interior');
    alt.removeIpl('sp1_10_fake_interior_lod');
    alt.requestIpl('sp1_10_real_interior');
    alt.requestIpl('sp1_10_real_interior_lod');
    alt.removeIpl('id2_14_during_door');
    alt.removeIpl('id2_14_during1');
    alt.removeIpl('id2_14_during2');
    alt.removeIpl('id2_14_on_fire');
    alt.removeIpl('id2_14_post_no_int');
    alt.removeIpl('id2_14_pre_no_int');
    alt.removeIpl('id2_14_during_door');
    alt.requestIpl('id2_14_during1');
    alt.removeIpl('Coroner_Int_off');
    alt.requestIpl('coronertrash');
    alt.requestIpl('Coroner_Int_on');
    alt.removeIpl('bh1_16_refurb');
    alt.removeIpl('jewel2fake');
    alt.removeIpl('bh1_16_doors_shut');
    alt.requestIpl('refit_unload');
    alt.requestIpl('post_hiest_unload');
    alt.requestIpl('Carwash_with_spinners');
    alt.requestIpl('KT_CarWash');
    alt.requestIpl('ferris_finale_Anim');
    alt.removeIpl('ch1_02_closed');
    alt.requestIpl('ch1_02_open');
    alt.requestIpl('AP1_04_TriAf01');
    alt.requestIpl('CS2_06_TriAf02');
    alt.requestIpl('CS4_04_TriAf03');
    alt.removeIpl('scafstartimap');
    alt.requestIpl('scafendimap');
    alt.removeIpl('DT1_05_HC_REMOVE');
    alt.requestIpl('DT1_05_HC_REQ');
    alt.requestIpl('DT1_05_REQUEST');
    alt.requestIpl('dt1_05_hc_remove');
    alt.requestIpl('dt1_05_hc_remove_lod');
    alt.requestIpl('FINBANK');
    alt.removeIpl('DT1_03_Shutter');
    alt.removeIpl('DT1_03_Gr_Closed');
    alt.requestIpl('golfflags');
    alt.requestIpl('airfield');
    alt.requestIpl('v_garages');
    alt.requestIpl('v_foundry');
    alt.requestIpl('hei_yacht_heist');
    alt.requestIpl('hei_yacht_heist_Bar');
    alt.requestIpl('hei_yacht_heist_Bedrm');
    alt.requestIpl('hei_yacht_heist_Bridge');
    alt.requestIpl('hei_yacht_heist_DistantLights');
    alt.requestIpl('hei_yacht_heist_enginrm');
    alt.requestIpl('hei_yacht_heist_LODLights');
    alt.requestIpl('hei_yacht_heist_Lounge');
    alt.requestIpl('hei_carrier');
    alt.requestIpl('hei_Carrier_int1');
    alt.requestIpl('hei_Carrier_int2');
    alt.requestIpl('hei_Carrier_int3');
    alt.requestIpl('hei_Carrier_int4');
    alt.requestIpl('hei_Carrier_int5');
    alt.requestIpl('hei_Carrier_int6');
    alt.requestIpl('hei_carrier_LODLights');
    alt.requestIpl('bkr_bi_id1_23_door');
    alt.requestIpl('lr_cs6_08_grave_closed');
    alt.requestIpl('hei_sm_16_interior_v_bahama_milo_');
    alt.requestIpl('CS3_07_MPGates');
    alt.requestIpl('cs5_4_trains');
    alt.requestIpl('v_lesters');
    alt.requestIpl('v_trevors');
    alt.requestIpl('v_michael');
    alt.requestIpl('v_comedy');
    alt.requestIpl('v_cinema');
    alt.requestIpl('V_Sweat');
    alt.requestIpl('V_35_Fireman');
    alt.requestIpl('redCarpet');
    alt.requestIpl('triathlon2_VBprops');
    alt.requestIpl('jetstenativeurnel');
    alt.requestIpl('Jetsteal_ipl_grp1');
    alt.requestIpl('v_hospital');
    alt.removeIpl('RC12B_Default');
    alt.removeIpl('RC12B_Fixed');
    alt.requestIpl('RC12B_Destroyed');
    alt.requestIpl('RC12B_HospitalInterior');
    alt.requestIpl('canyonriver01');
    alt.requestIpl('canyonriver01_lod');
    alt.requestIpl('cs3_05_water_grp1');
    alt.requestIpl('cs3_05_water_grp1_lod');
    alt.requestIpl('trv1_trail_start');
    alt.requestIpl('CanyonRvrShallow');
    // CASINO
    alt.requestIpl('vw_casino_penthouse');
    alt.requestIpl('vw_casino_main');
    alt.requestIpl('vw_casino_carpark');
    alt.requestIpl('vw_dlc_casino_door');
    alt.requestIpl('vw_casino_door');
    alt.requestIpl('hei_dlc_windows_casino');
    alt.requestIpl('hei_dlc_casino_door');
    alt.requestIpl('hei_dlc_casino_aircon');
    alt.requestIpl('vw_casino_garage');
    let interiorID = native.getInteriorAtCoords(1100.0, 220.0, -50.0);
    if (native.isValidInterior(interiorID)) {
        native.activateInteriorEntitySet(interiorID, '0x30240D11');
        native.activateInteriorEntitySet(interiorID, '0xA3C89BB2');
        native.refreshInterior(interiorID);
    }
    interiorID = native.getInteriorAtCoords(976.6364, 70.29476, 115.1641);
    if (native.isValidInterior(interiorID)) {
        native.activateInteriorEntitySet(interiorID, 'Set_Pent_Arcade_Modern');
        native.setInteriorEntitySetTintIndex(interiorID, 'Set_Pent_Arcade_Modern', 3);
        native.activateInteriorEntitySet(interiorID, 'set_pent_bar_party_2');
        native.setInteriorEntitySetTintIndex(interiorID, 'set_pent_bar_party_2', 3);
        native.activateInteriorEntitySet(interiorID, 'Set_pent_bar_light_02');
        native.setInteriorEntitySetTintIndex(interiorID, 'Set_pent_bar_light_02', 3);
        native.activateInteriorEntitySet(interiorID, 'Set_Pent_Tint_Shell');
        native.setInteriorEntitySetTintIndex(interiorID, 'Set_Pent_Tint_Shell', 3);
        native.activateInteriorEntitySet(interiorID, 'Set_Pent_Pattern_09');
        native.setInteriorEntitySetTintIndex(interiorID, 'Set_Pent_Pattern_09', 3);
        native.activateInteriorEntitySet(interiorID, 'Set_Pent_Spa_Bar_Open');
        native.setInteriorEntitySetTintIndex(interiorID, 'Set_Pent_Spa_Bar_Open', 3);
        native.activateInteriorEntitySet(interiorID, 'Set_Pent_Media_Bar_Open');
        native.setInteriorEntitySetTintIndex(interiorID, 'Set_Pent_Media_Bar_Open', 3);
        native.activateInteriorEntitySet(interiorID, 'Set_Pent_Bar_Clutter');
        native.setInteriorEntitySetTintIndex(interiorID, 'Set_Pent_Bar_Clutter', 3);
        native.activateInteriorEntitySet(interiorID, 'Set_Pent_Clutter_03');
        native.setInteriorEntitySetTintIndex(interiorID, 'Set_Pent_Clutter_03', 3);
        native.refreshInterior(interiorID);
    }
    //Tuner
    alt.requestIpl('tr_tuner_meetup');
    alt.requestIpl('tr_tuner_race_line');
    alt.requestIpl('tr_tuner_shop_burton');
    alt.requestIpl('tr_tuner_shop_mesa');
    alt.requestIpl('tr_tuner_shop_mission');
    alt.requestIpl('tr_tuner_shop_rancho');
    alt.requestIpl('tr_tuner_shop_strawberry');
    interiorID = native.getInteriorAtCoords(-1350.0, 160.0, -100.0);
    if (native.isValidInterior(interiorID)) {
        native.activateInteriorEntitySet(interiorID, 'entity_set_style_2');
        native.activateInteriorEntitySet(interiorID, 'entity_set_tints');
        native.setInteriorEntitySetTintIndex(interiorID, 'entity_set_tints', 7);
        native.activateInteriorEntitySet(interiorID, 'entity_set_car_lift_purchase');
        native.activateInteriorEntitySet(interiorID, 'entity_set_bedroom');
        native.activateInteriorEntitySet(interiorID, 'entity_set_cabinets');
        native.refreshInterior(interiorID);
    }
}
