﻿using System.Collections.Generic;
using System.Text.Json;

namespace binstarjs03.AerialOBJ.Core.Definitions;
public class ViewportDefinition : IRootDefinition
{
    public required string Name { get; set; }
    public required int FormatVersion { get; set; }
    public required string MinecraftVersion { get; set; }
    public required ViewportBlockDefinition MissingBlockDefinition { get; set; }
    public required Dictionary<string, ViewportBlockDefinition> BlockDefinitions { get; set; }

    public static ViewportDefinition GetDefaultDefinition()
    {
        string input = /*lang=json*/ """
        {
            "Name": "Default Definitions",
            "FormatVersion": 1,
            "MinecraftVersion": "1.18",
            "MissingBlockDefinition": {
                "Color": "#FFFF00CC",
                "LightLevel": 0,
                "DisplayName": "Unknown (Missing Definition)"
            },
            "BlockDefinitions": {
                "minecraft:air": {
                    "Color": "#00000000",
                    "LightLevel": 0,
                    "DisplayName": "Air"
                },
                "minecraft:cave_air": {
                    "Color": "#00000000",
                    "LightLevel": 0,
                    "DisplayName": "Air (Cave)"
                },
                "minecraft:stone": {
                    "Color": "#FF737373",
                    "LightLevel": 0,
                    "DisplayName": "Stone"
                },
                "minecraft:stone_bricks": {
                    "Color": "#FF606060",
                    "LightLevel": 0,
                    "DisplayName": "Stone Bricks"
                },
                "minecraft:mossy_stone_bricks": {
                    "Color": "#FF4C6056",
                    "LightLevel": 0,
                    "DisplayName": "Mossy Stone Bricks"
                },
                "minecraft:cracked_stone_bricks": {
                    "Color": "#FF606060",
                    "LightLevel": 0,
                    "DisplayName": "Cracked Stone Bricks"
                },
                "minecraft:chiseled_stone_bricks": {
                    "Color": "#FF606060",
                    "LightLevel": 0,
                    "DisplayName": "Chiseled Stone Bricks"
                },
                "minecraft:smooth_stone": {
                    "Color": "#FF808080",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Stone"
                },
                "minecraft:cobblestone": {
                    "Color": "#FF808080",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Stone"
                },
                "minecraft:mossy_cobblestone": {
                    "Color": "#FF808080",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Stone"
                },
                "minecraft:granite": {
                    "Color": "#FF8D5B48",
                    "LightLevel": 0,
                    "DisplayName": "Granite"
                },
                "minecraft:andesite": {
                    "Color": "#FF656565",
                    "LightLevel": 0,
                    "DisplayName": "Andesite"
                },
                "minecraft:diorite": {
                    "Color": "#FFA0A0A0",
                    "LightLevel": 0,
                    "DisplayName": "Diorite"
                },
                "minecraft:polished_granite": {
                    "Color": "#FF8D5B48",
                    "LightLevel": 0,
                    "DisplayName": "Polished Granite"
                },
                "minecraft:polished_andesite": {
                    "Color": "#FF656565",
                    "LightLevel": 0,
                    "DisplayName": "Polished Andesite"
                },
                "minecraft:polished_diorite": {
                    "Color": "#FFA0A0A0",
                    "LightLevel": 0,
                    "DisplayName": "Polished Diorite"
                },
                "minecraft:bedrock": {
                    "Color": "#FF444444",
                    "LightLevel": 0,
                    "DisplayName": "Bedrock"
                },
                "minecraft:calcite": {
                    "Color": "#FFB3B3B3",
                    "LightLevel": 0,
                    "DisplayName": "Calcite"
                },
                "minecraft:tuff": {
                    "Color": "#FF585852",
                    "LightLevel": 0,
                    "DisplayName": "Tuff"
                },
                "minecraft:dripstone_block": {
                    "Color": "#FF705646",
                    "LightLevel": 0,
                    "DisplayName": "Dripstone Block"
                },
                "minecraft:gravel": {
                    "Color": "#FF6B6161",
                    "LightLevel": 0,
                    "DisplayName": "Gravel"
                },
                "minecraft:clay": {
                    "Color": "#FF808592",
                    "LightLevel": 0,
                    "DisplayName": "Clay"
                },
                "minecraft:bricks": {
                    "Color": "#FF83402D",
                    "LightLevel": 0,
                    "DisplayName": "Bricks"
                },
                "minecraft:obsidian": {
                    "Color": "#FF151123",
                    "LightLevel": 0,
                    "DisplayName": "Obsidian"
                },
                "minecraft:crying_obsidian": {
                    "Color": "#FF2A0954",
                    "LightLevel": 10,
                    "DisplayName": "Crying Obsidian"
                },
                "minecraft:deepslate": {
                    "Color": "#FF535353",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate"
                },
                "minecraft:cobbled_deepslate": {
                    "Color": "#FF535353",
                    "LightLevel": 0,
                    "DisplayName": "Cobbled Deepslate"
                },
                "minecraft:polished_deepslate": {
                    "Color": "#FF535353",
                    "LightLevel": 0,
                    "DisplayName": "Polished Deepslate"
                },
                "minecraft:deepslate_bricks": {
                    "Color": "#FF4C4C4C",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Bricks"
                },
                "minecraft:cracked_deepslate_bricks": {
                    "Color": "#FF4C4C4C",
                    "LightLevel": 0,
                    "DisplayName": "Cracked Deepslate Bricks"
                },
                "minecraft:deepslate_tiles": {
                    "Color": "#FF2D2D2D",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Tiles"
                },
                "minecraft:cracked_deepslate_tiles": {
                    "Color": "#FF2D2D2D",
                    "LightLevel": 0,
                    "DisplayName": "Cracked Deepslate Tiles"
                },
                "minecraft:chiseled_deepslate_tiles": {
                    "Color": "#FF2D2D2D",
                    "LightLevel": 0,
                    "DisplayName": "Chiseled Deepslate Tiles"
                },
                "minecraft:amethyst_block": {
                    "Color": "#FF6E4F9C",
                    "LightLevel": 0,
                    "DisplayName": "Amethyst Block"
                },
                "minecraft:budding_amethyst": {
                    "Color": "#FF6E4F9C",
                    "LightLevel": 0,
                    "DisplayName": "Budding Amethyst"
                },
                "minecraft:netherrack": {
                    "Color": "#FF6D3533",
                    "LightLevel": 0,
                    "DisplayName": "Netherrack"
                },
                "minecraft:soul_sand": {
                    "Color": "#FF473326",
                    "LightLevel": 0,
                    "DisplayName": "Soul Sand"
                },
                "minecraft:soul_soil": {
                    "Color": "#FF473326",
                    "LightLevel": 0,
                    "DisplayName": "Soul Soil"
                },
                "minecraft:crimson_nylium": {
                    "Color": "#FF771919",
                    "LightLevel": 0,
                    "DisplayName": "Crimson Nylium"
                },
                "minecraft:warped_nylium": {
                    "Color": "#FF206154",
                    "LightLevel": 0,
                    "DisplayName": "Warped Nylium"
                },
                "minecraft:magma_block": {
                    "Color": "#FF893A09",
                    "LightLevel": 3,
                    "DisplayName": "Magma Block"
                },
                "minecraft:glowstone": {
                    "Color": "#FFCDA870",
                    "LightLevel": 15,
                    "DisplayName": "Glowstone"
                },
                "minecraft:basalt": {
                    "Color": "#FF505050",
                    "LightLevel": 0,
                    "DisplayName": "Basalt"
                },
                "minecraft:polished_basalt": {
                    "Color": "#FF525252",
                    "LightLevel": 0,
                    "DisplayName": "Polished Basalt"
                },
                "minecraft:smooth_basalt": {
                    "Color": "#FF3B3B3B",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Basalt"
                },
                "minecraft:nether_bricks": {
                    "Color": "#FF2B1010",
                    "LightLevel": 0,
                    "DisplayName": "Nether Bricks"
                },
                "minecraft:cracked_nether_bricks": {
                    "Color": "#FF2B1010",
                    "LightLevel": 0,
                    "DisplayName": "Cracked Nether Bricks"
                },
                "minecraft:chiseled_nether_bricks": {
                    "Color": "#FF2B1010",
                    "LightLevel": 0,
                    "DisplayName": "Chiseled Nether Bricks"
                },
                "minecraft:red_nether_bricks": {
                    "Color": "#FF410101",
                    "LightLevel": 0,
                    "DisplayName": "Red Nether Bricks"
                },
                "minecraft:blackstone": {
                    "Color": "#FF2A252C",
                    "LightLevel": 0,
                    "DisplayName": "Blackstone"
                },
                "minecraft:giled_blackstone": {
                    "Color": "#FF2A252C",
                    "LightLevel": 0,
                    "DisplayName": "Gilded Blackstone"
                },
                "minecraft:polished_blackstone": {
                    "Color": "#FF2A252C",
                    "LightLevel": 0,
                    "DisplayName": "Polished Blackstone"
                },
                "minecraft:chiseled_polished_blackstone": {
                    "Color": "#FF3E3641",
                    "LightLevel": 0,
                    "DisplayName": "Chiseled Polished Blackstone"
                },
                "minecraft:polished_blackstone_bricks": {
                    "Color": "#FF3E3641",
                    "LightLevel": 0,
                    "DisplayName": "Polished Blackstone Bricks"
                },
                "minecraft:cracked_polished_blackstone_bricks": {
                    "Color": "#FF3E3641",
                    "LightLevel": 0,
                    "DisplayName": "Cracked Polished Blackstone Bricks"
                },
                "minecraft:end_stone": {
                    "Color": "#FFCBCD97",
                    "LightLevel": 0,
                    "DisplayName": "End Stone"
                },
                "minecraft:end_stone_bricks": {
                    "Color": "#FFCBCD97",
                    "LightLevel": 0,
                    "DisplayName": "End Stone Bricks"
                },
                "minecraft:purpur_block": {
                    "Color": "#FF8A5E8A",
                    "LightLevel": 0,
                    "DisplayName": "Purpur Block"
                },
                "minecraft:purpur_pillar": {
                    "Color": "#FF8A5E8A",
                    "LightLevel": 0,
                    "DisplayName": "Purpur Pillar"
                },
                "minecraft:quartz_block": {
                    "Color": "#FFD1CEC8",
                    "LightLevel": 0,
                    "DisplayName": "Quartz Block"
                },
                "minecraft:quartz_bricks": {
                    "Color": "#FFB3B0AA",
                    "LightLevel": 0,
                    "DisplayName": "Quartz Bricks"
                },
                "minecraft:quartz_pillar": {
                    "Color": "#FFB3B0AA",
                    "LightLevel": 0,
                    "DisplayName": "Quartz Pillar"
                },
                "minecraft:chiseled_quartz_block": {
                    "Color": "#FFB3B0AA",
                    "LightLevel": 0,
                    "DisplayName": "Chiseled Quartz Block"
                },
                "minecraft:smooth_quartz": {
                    "Color": "#FFD1CEC8",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Quartz"
                },
                "minecraft:sand": {
                    "Color": "#FFCEC298",
                    "LightLevel": 0,
                    "DisplayName": "Sand"
                },
                "minecraft:sandstone": {
                    "Color": "#FFB5AD7B",
                    "LightLevel": 0,
                    "DisplayName": "Sandstone"
                },
                "minecraft:smooth_sandstone": {
                    "Color": "#FFB5AD7B",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Sandstone"
                },
                "minecraft:cut_sandstone": {
                    "Color": "#FFB5AD7B",
                    "LightLevel": 0,
                    "DisplayName": "Cut Sandstone"
                },
                "minecraft:Chiseled_sandstone": {
                    "Color": "#FFB5AD7B",
                    "LightLevel": 0,
                    "DisplayName": "Chiseled Sandstone"
                },
                "minecraft:red_sand": {
                    "Color": "#FF933F0B",
                    "LightLevel": 0,
                    "DisplayName": "Red Sand"
                },
                "minecraft:red_sandstone": {
                    "Color": "#FF833906",
                    "LightLevel": 0,
                    "DisplayName": "Red Sandstone"
                },
                "minecraft:smooth_red_sandstone": {
                    "Color": "#FF833906",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Red Sandstone"
                },
                "minecraft:cut_red_sandstone": {
                    "Color": "#FF833906",
                    "LightLevel": 0,
                    "DisplayName": "Cut Red Sandstone"
                },
                "minecraft:chiseled_red_sandstone": {
                    "Color": "#FF833906",
                    "LightLevel": 0,
                    "DisplayName": "Chiseled Red Sandstone"
                },
                "minecraft:grass_block": {
                    "Color": "#FF5D923A",
                    "LightLevel": 0,
                    "DisplayName": "Grass Block"
                },
                "minecraft:dirt": {
                    "Color": "#FF845B3C",
                    "LightLevel": 0,
                    "DisplayName": "Dirt"
                },
                "minecraft:coarse_dirt": {
                    "Color": "#FF69462B",
                    "LightLevel": 0,
                    "DisplayName": "Coarse Dirt"
                },
                "minecraft:rooted_dirt": {
                    "Color": "#FF69462B",
                    "LightLevel": 0,
                    "DisplayName": "Rooted Dirt"
                },
                "minecraft:podzol": {
                    "Color": "#FF51330A",
                    "LightLevel": 0,
                    "DisplayName": "Podzol"
                },
                "minecraft:mycelium": {
                    "Color": "#FF544955",
                    "LightLevel": 0,
                    "DisplayName": "Mycelium"
                },
                "minecraft:prismarine": {
                    "Color": "#FF5DA28C",
                    "LightLevel": 0,
                    "DisplayName": "Prismarine"
                },
                "minecraft:prismarine_bricks": {
                    "Color": "#FF78B5A6",
                    "LightLevel": 0,
                    "DisplayName": "Prismarine Bricks"
                },
                "minecraft:dark_prismarine": {
                    "Color": "#FF244E3D",
                    "LightLevel": 0,
                    "DisplayName": "Dark Prismarine"
                },
                "minecraft:sea_lantern": {
                    "Color": "#FFA7AFA7",
                    "LightLevel": 14,
                    "DisplayName": "Sea Lantern"
                },
                "minecraft:sponge": {
                    "Color": "#FFAAAB27",
                    "LightLevel": 0,
                    "DisplayName": "Sponge"
                },
                "minecraft:wet_sponge": {
                    "Color": "#FF7D7C0D",
                    "LightLevel": 0,
                    "DisplayName": "Wet Sponge"
                },
                "minecraft:dried_kelp_block": {
                    "Color": "#FF333726",
                    "LightLevel": 0,
                    "DisplayName": "Dried Kelp Block"
                },
                "minecraft:coal_ore": {
                    "Color": "#FF303030",
                    "LightLevel": 0,
                    "DisplayName": "Coal Ore"
                },
                "minecraft:iron_ore": {
                    "Color": "#FF9B785F",
                    "LightLevel": 0,
                    "DisplayName": "Iron Ore"
                },
                "minecraft:copper_ore": {
                    "Color": "#FF7B542D",
                    "LightLevel": 0,
                    "DisplayName": "Copper Ore"
                },
                "minecraft:gold_ore": {
                    "Color": "#FFCFC11E",
                    "LightLevel": 0,
                    "DisplayName": "Gold Ore"
                },
                "minecraft:redstone_ore": {
                    "Color": "#FF860000",
                    "LightLevel": 0,
                    "DisplayName": "Redstone Ore"
                },
                "minecraft:emerald_ore": {
                    "Color": "#FF617265",
                    "LightLevel": 0,
                    "DisplayName": "Emerald Ore"
                },
                "minecraft:lapis_ore": {
                    "Color": "#FF092D75",
                    "LightLevel": 0,
                    "DisplayName": "Lapis Lazuli Ore"
                },
                "minecraft:diamond_ore": {
                    "Color": "#FF36C5CE",
                    "LightLevel": 0,
                    "DisplayName": "Diamond Ore"
                },
                "minecraft:deepslate_coal_ore": {
                    "Color": "#FF202020",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Coal Ore"
                },
                "minecraft:deepslate_iron_ore": {
                    "Color": "#FF735846",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Iron Ore"
                },
                "minecraft:deepslate_copper_ore": {
                    "Color": "#FF53381E",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Copper Ore"
                },
                "minecraft:deepslate_gold_ore": {
                    "Color": "#FFA79B18",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Gold Ore"
                },
                "minecraft:deepslate_redstone_ore": {
                    "Color": "#FF653E3F",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Redstone Ore"
                },
                "minecraft:deepslate_emerald_ore": {
                    "Color": "#FF3F4A41",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Emerald Ore"
                },
                "minecraft:deepslate_lapis_ore": {
                    "Color": "#FF051D4D",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Lapis Lazuli Ore"
                },
                "minecraft:deepslate_diamond_ore": {
                    "Color": "#FF2BA0A6",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Diamond Ore"
                },
                "minecraft:raw_iron_block": {
                    "Color": "#FFA2836A",
                    "LightLevel": 0,
                    "DisplayName": "Block of Raw Iron"
                },
                "minecraft:raw_copper_block": {
                    "Color": "#FF8A543A",
                    "LightLevel": 0,
                    "DisplayName": "Block of Raw Copper"
                },
                "minecraft:raw_gold_block": {
                    "Color": "#FFBC8C1A",
                    "LightLevel": 0,
                    "DisplayName": "Block of Raw Gold"
                },
                "minecraft:coal_block": {
                    "Color": "#FF171717",
                    "LightLevel": 0,
                    "DisplayName": "Block of Coal"
                },
                "minecraft:iron_block": {
                    "Color": "#FFBEBEBE",
                    "LightLevel": 0,
                    "DisplayName": "Block of Iron"
                },
                "minecraft:copper_block": {
                    "Color": "#FFA75237",
                    "LightLevel": 0,
                    "DisplayName": "Block of Copper"
                },
                "minecraft:gold_block": {
                    "Color": "#FFD0C920",
                    "LightLevel": 0,
                    "DisplayName": "Block of Gold"
                },
                "minecraft:redstone_block": {
                    "Color": "#FF9A1000",
                    "LightLevel": 0,
                    "DisplayName": "Block of Redstone"
                },
                "minecraft:emerald_block": {
                    "Color": "#FF32B657",
                    "LightLevel": 0,
                    "DisplayName": "Block of Emerald"
                },
                "minecraft:lapis_block": {
                    "Color": "#FF0B3EAB",
                    "LightLevel": 0,
                    "DisplayName": "Block of Lapis Lazuli"
                },
                "minecraft:diamond_block": {
                    "Color": "#FF57BBB7",
                    "LightLevel": 0,
                    "DisplayName": "Block of Diamond"
                },
                "minecraft:netherite_block": {
                    "Color": "#FF363234",
                    "LightLevel": 0,
                    "DisplayName": "Block of Netherite"
                },
                "minecraft:nether_gold_ore": {
                    "Color": "#FF78482B",
                    "LightLevel": 0,
                    "DisplayName": "Nether Gold Ore"
                },
                "minecraft:nether_quartz_ore": {
                    "Color": "#FF664743",
                    "LightLevel": 0,
                    "DisplayName": "Nether Quartz Ore"
                },
                "minecraft:ancient_debris": {
                    "Color": "#FF553E38",
                    "LightLevel": 0,
                    "DisplayName": "Ancient Debris"
                },
                "minecraft:exposed_copper": {
                    "Color": "#FF9A7560",
                    "LightLevel": 0,
                    "DisplayName": "Exposed Copper"
                },
                "minecraft:weathered_copper": {
                    "Color": "#FF547853",
                    "LightLevel": 0,
                    "DisplayName": "Weathered Copper"
                },
                "minecraft:oxidized_copper": {
                    "Color": "#FF38896B",
                    "LightLevel": 0,
                    "DisplayName": "Oxidized Copper"
                },
                "minecraft:cut_copper": {
                    "Color": "#FFA75237",
                    "LightLevel": 0,
                    "DisplayName": "Cut Copper"
                },
                "minecraft:exposed_cut_copper": {
                    "Color": "#FF9A7560",
                    "LightLevel": 0,
                    "DisplayName": "Exposed Cut Copper"
                },
                "minecraft:weathered_cut_copper": {
                    "Color": "#FF547853",
                    "LightLevel": 0,
                    "DisplayName": "Weathered Cut Copper"
                },
                "minecraft:oxidized_cut_copper": {
                    "Color": "#FF38896B",
                    "LightLevel": 0,
                    "DisplayName": "Oxidized Cut Copper"
                },
                "minecraft:waxed_copper": {
                    "Color": "#FFA75237",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Block of Copper"
                },
                "minecraft:waxed_exposed_copper": {
                    "Color": "#FF9A7560",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Exposed Copper"
                },
                "minecraft:waxed_weathered_copper": {
                    "Color": "#FF547853",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Weathered Copper"
                },
                "minecraft:waxed_oxidized_copper": {
                    "Color": "#FF38896B",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Oxidized Copper"
                },
                "minecraft:waxed_cut_copper": {
                    "Color": "#FFA75237",
                    "LightLevel": 0,
                    "DisplayName": "Cut Copper"
                },
                "minecraft:waxed_exposed_cut_copper": {
                    "Color": "#FF9A7560",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Exposed Cut Copper"
                },
                "minecraft:waxed_weathered_cut_copper": {
                    "Color": "#FF547853",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Weathered Cut Copper"
                },
                "minecraft:waxed_oxidized_cut_copper": {
                    "Color": "#FF38896B",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Oxidized Cut Copper"
                },
                "minecraft:dead_tube_coral_block": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Tube Coral Block"
                },
                "minecraft:dead_brain_coral_block": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Brain Coral Block"
                },
                "minecraft:dead_bubble_coral_block": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Bubble Coral Block"
                },
                "minecraft:dead_fire_coral_block": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Fire Coral Block"
                },
                "minecraft:dead_horn_coral_block": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Horn Coral Block"
                },
                "minecraft:tube_coral_block": {
                    "Color": "#FF2C51C4",
                    "LightLevel": 0,
                    "DisplayName": "Tube Coral Block"
                },
                "minecraft:brain_coral_block": {
                    "Color": "#FFAD4280",
                    "LightLevel": 0,
                    "DisplayName": "Brain Coral Block"
                },
                "minecraft:bubble_coral_block": {
                    "Color": "#FF940C90",
                    "LightLevel": 0,
                    "DisplayName": "Bubble Coral Block"
                },
                "minecraft:fire_coral_block": {
                    "Color": "#FF9B171E",
                    "LightLevel": 0,
                    "DisplayName": "Fire Coral Block"
                },
                "minecraft:horn_coral_block": {
                    "Color": "#FFAD991B",
                    "LightLevel": 0,
                    "DisplayName": "Horn Coral Block"
                },
                "minecraft:white_concrete": {
                    "Color": "#FFC7C7C7",
                    "LightLevel": 0,
                    "DisplayName": "White Concrete"
                },
                "minecraft:orange_concrete": {
                    "Color": "#FFC74800",
                    "LightLevel": 0,
                    "DisplayName": "Orange Concrete"
                },
                "minecraft:magenta_concrete": {
                    "Color": "#FF951C8B",
                    "LightLevel": 0,
                    "DisplayName": "Magenta Concrete"
                },
                "minecraft:light_blue_concrete": {
                    "Color": "#FF0D72B0",
                    "LightLevel": 0,
                    "DisplayName": "Light Blue Concrete"
                },
                "minecraft:yellow_concrete": {
                    "Color": "#FFCD8B00",
                    "LightLevel": 0,
                    "DisplayName": "Yellow Concrete"
                },
                "minecraft:lime_concrete": {
                    "Color": "#FF438E00",
                    "LightLevel": 0,
                    "DisplayName": "Lime Concrete"
                },
                "minecraft:pink_concrete": {
                    "Color": "#FFBA4973",
                    "LightLevel": 0,
                    "DisplayName": "Pink Concrete"
                },
                "minecraft:gray_concrete": {
                    "Color": "#FF323232",
                    "LightLevel": 0,
                    "DisplayName": "Gray Concrete"
                },
                "minecraft:light_gray_concrete": {
                    "Color": "#FF646464",
                    "LightLevel": 0,
                    "DisplayName": "Light Gray Concrete"
                },
                "minecraft:cyan_concrete": {
                    "Color": "#FF026475",
                    "LightLevel": 0,
                    "DisplayName": "Cyan Concrete"
                },
                "minecraft:purple_concrete": {
                    "Color": "#FF56128E",
                    "LightLevel": 0,
                    "DisplayName": "Purple Concrete"
                },
                "minecraft:blue_concrete": {
                    "Color": "#FF212383",
                    "LightLevel": 0,
                    "DisplayName": "Blue Concrete"
                },
                "minecraft:brown_concrete": {
                    "Color": "#FF522E12",
                    "LightLevel": 0,
                    "DisplayName": "Brown Concrete"
                },
                "minecraft:green_concrete": {
                    "Color": "#FF394B14",
                    "LightLevel": 0,
                    "DisplayName": "Green Concrete"
                },
                "minecraft:red_concrete": {
                    "Color": "#FF801313",
                    "LightLevel": 0,
                    "DisplayName": "Red Concrete"
                },
                "minecraft:black_concrete": {
                    "Color": "#FF0D0D0D",
                    "LightLevel": 0,
                    "DisplayName": "Black Concrete"
                },
                "minecraft:white_concrete_powder": {
                    "Color": "#FFE3E3E3",
                    "LightLevel": 0,
                    "DisplayName": "White Concrete Powder"
                },
                "minecraft:orange_concrete_powder": {
                    "Color": "#FFE35300",
                    "LightLevel": 0,
                    "DisplayName": "Orange Concrete Powder"
                },
                "minecraft:magenta_concrete_powder": {
                    "Color": "#FFBC26AF",
                    "LightLevel": 0,
                    "DisplayName": "Magenta Concrete Powder"
                },
                "minecraft:light_blue_concrete_powder": {
                    "Color": "#FF1288D0",
                    "LightLevel": 0,
                    "DisplayName": "Light Blue Concrete Powder"
                },
                "minecraft:yellow_concrete_powder": {
                    "Color": "#FFE89E00",
                    "LightLevel": 0,
                    "DisplayName": "Yellow Concrete Powder"
                },
                "minecraft:lime_concrete_powder": {
                    "Color": "#FF58B600",
                    "LightLevel": 0,
                    "DisplayName": "Lime Concrete Powder"
                },
                "minecraft:pink_concrete_powder": {
                    "Color": "#FFD95687",
                    "LightLevel": 0,
                    "DisplayName": "Pink Concrete Powder"
                },
                "minecraft:gray_concrete_powder": {
                    "Color": "#FF9B9B9B",
                    "LightLevel": 0,
                    "DisplayName": "Gray Concrete Powder"
                },
                "minecraft:light_gray_concrete_powder": {
                    "Color": "#FF7C7C76",
                    "LightLevel": 0,
                    "DisplayName": "Light Gray Concrete Powder"
                },
                "minecraft:cyan_concrete_powder": {
                    "Color": "#FF048EA5",
                    "LightLevel": 0,
                    "DisplayName": "Cyan Concrete Powder"
                },
                "minecraft:purple_concrete_powder": {
                    "Color": "#FF701AB6",
                    "LightLevel": 0,
                    "DisplayName": "Purple Concrete Powder"
                },
                "minecraft:blue_concrete_powder": {
                    "Color": "#FF2F32AF",
                    "LightLevel": 0,
                    "DisplayName": "Blue Concrete Powder"
                },
                "minecraft:brown_concrete_powder": {
                    "Color": "#FF77451E",
                    "LightLevel": 0,
                    "DisplayName": "Brown Concrete Powder"
                },
                "minecraft:green_concrete_powder": {
                    "Color": "#FF597323",
                    "LightLevel": 0,
                    "DisplayName": "Green Concrete Powder"
                },
                "minecraft:red_concrete_powder": {
                    "Color": "#FFAD1D1D",
                    "LightLevel": 0,
                    "DisplayName": "Red Concrete Powder"
                },
                "minecraft:black_concrete_powder": {
                    "Color": "#FF424242",
                    "LightLevel": 0,
                    "DisplayName": "Black Concrete Powder"
                },
                "minecraft:terracotta": {
                    "Color": "#FF8D533A",
                    "LightLevel": 0,
                    "DisplayName": "Terracotta"
                },
                "minecraft:white_terracotta": {
                    "Color": "#FFA98979",
                    "LightLevel": 0,
                    "DisplayName": "White Terracotta"
                },
                "minecraft:orange_terracotta": {
                    "Color": "#FF893C0D",
                    "LightLevel": 0,
                    "DisplayName": "Orange Terracotta"
                },
                "minecraft:magenta_terracotta": {
                    "Color": "#FF7D3F54",
                    "LightLevel": 0,
                    "DisplayName": "Magenta Terracotta"
                },
                "minecraft:yellow_terracotta": {
                    "Color": "#FF9B6504",
                    "LightLevel": 0,
                    "DisplayName": "Yellow Terracotta"
                },
                "minecraft:lime_terracotta": {
                    "Color": "#FF4F5D1B",
                    "LightLevel": 0,
                    "DisplayName": "Lime Terracotta"
                },
                "minecraft:pink_terracotta": {
                    "Color": "#FF893637",
                    "LightLevel": 0,
                    "DisplayName": "Pink Terracotta"
                },
                "minecraft:gray_terracotta": {
                    "Color": "#FF2D1D18",
                    "LightLevel": 0,
                    "DisplayName": "Gray Terracotta"
                },
                "minecraft:light_gray_terracotta": {
                    "Color": "#FF6E5047",
                    "LightLevel": 0,
                    "DisplayName": "Light Gray Terracotta"
                },
                "minecraft:cyan_terracotta": {
                    "Color": "#FF414546",
                    "LightLevel": 0,
                    "DisplayName": "Cyan Terracotta"
                },
                "minecraft:purple_terracotta": {
                    "Color": "#FF623142",
                    "LightLevel": 0,
                    "DisplayName": "Purple Terracotta"
                },
                "minecraft:blue_terracotta": {
                    "Color": "#FF3A2B4B",
                    "LightLevel": 0,
                    "DisplayName": "Blue Terracotta"
                },
                "minecraft:brown_terracotta": {
                    "Color": "#FF3F2416",
                    "LightLevel": 0,
                    "DisplayName": "Brown Terracotta"
                },
                "minecraft:green_terracotta": {
                    "Color": "#FF394018",
                    "LightLevel": 0,
                    "DisplayName": "Green Terracotta"
                },
                "minecraft:red_terracotta": {
                    "Color": "#FF7B291B",
                    "LightLevel": 0,
                    "DisplayName": "Red Terracotta"
                },
                "minecraft:black_terracotta": {
                    "Color": "#FF1C0D08",
                    "LightLevel": 0,
                    "DisplayName": "Black Terracotta"
                },
                "minecraft:white_wool": {
                    "Color": "#FFE3E3E3",
                    "LightLevel": 0,
                    "DisplayName": "White Wool"
                },
                "minecraft:orange_wool": {
                    "Color": "#FFE35300",
                    "LightLevel": 0,
                    "DisplayName": "Orange Wool"
                },
                "minecraft:magenta_wool": {
                    "Color": "#FFBC26AF",
                    "LightLevel": 0,
                    "DisplayName": "Magenta Wool"
                },
                "minecraft:light_blue_wool": {
                    "Color": "#FF1288D0",
                    "LightLevel": 0,
                    "DisplayName": "Light Blue Wool"
                },
                "minecraft:yellow_wool": {
                    "Color": "#FFE89E00",
                    "LightLevel": 0,
                    "DisplayName": "Yellow Wool"
                },
                "minecraft:lime_wool": {
                    "Color": "#FF58B600",
                    "LightLevel": 0,
                    "DisplayName": "Lime Wool"
                },
                "minecraft:pink_wool": {
                    "Color": "#FFD95687",
                    "LightLevel": 0,
                    "DisplayName": "Pink Wool"
                },
                "minecraft:gray_wool": {
                    "Color": "#FF9B9B9B",
                    "LightLevel": 0,
                    "DisplayName": "Gray Wool"
                },
                "minecraft:light_gray_wool": {
                    "Color": "#FF7C7C76",
                    "LightLevel": 0,
                    "DisplayName": "Light Gray Wool"
                },
                "minecraft:cyan_wool": {
                    "Color": "#FF048EA5",
                    "LightLevel": 0,
                    "DisplayName": "Cyan Wool"
                },
                "minecraft:purple_wool": {
                    "Color": "#FF701AB6",
                    "LightLevel": 0,
                    "DisplayName": "Purple Wool"
                },
                "minecraft:blue_wool": {
                    "Color": "#FF2F32AF",
                    "LightLevel": 0,
                    "DisplayName": "Blue Wool"
                },
                "minecraft:brown_wool": {
                    "Color": "#FF77451E",
                    "LightLevel": 0,
                    "DisplayName": "Brown Wool"
                },
                "minecraft:green_wool": {
                    "Color": "#FF597323",
                    "LightLevel": 0,
                    "DisplayName": "Green Wool"
                },
                "minecraft:red_wool": {
                    "Color": "#FFAD1D1D",
                    "LightLevel": 0,
                    "DisplayName": "Red Wool"
                },
                "minecraft:black_wool": {
                    "Color": "#FF424242",
                    "LightLevel": 0,
                    "DisplayName": "Black Wool"
                },
                "minecraft:glass": {
                    "Color": "#80A6CED6",
                    "LightLevel": 0,
                    "DisplayName": "Glass"
                },
                "minecraft:tinted_glass": {
                    "Color": "#80252523",
                    "LightLevel": 0,
                    "DisplayName": "Tinted Glass"
                },
                "minecraft:white_stained_glass": {
                    "Color": "#80E3E3E3",
                    "LightLevel": 0,
                    "DisplayName": "White Stained Glass"
                },
                "minecraft:orange_stained_glass": {
                    "Color": "#80E35300",
                    "LightLevel": 0,
                    "DisplayName": "Orange Stained Glass"
                },
                "minecraft:magenta_stained_glass": {
                    "Color": "#80BC26AF",
                    "LightLevel": 0,
                    "DisplayName": "Magenta Stained Glass"
                },
                "minecraft:light_blue_stained_glass": {
                    "Color": "#801288D0",
                    "LightLevel": 0,
                    "DisplayName": "Light Blue Stained Glass"
                },
                "minecraft:yellow_stained_glass": {
                    "Color": "#80E89E00",
                    "LightLevel": 0,
                    "DisplayName": "Yellow Stained Glass"
                },
                "minecraft:lime_stained_glass": {
                    "Color": "#8058B600",
                    "LightLevel": 0,
                    "DisplayName": "Lime Stained Glass"
                },
                "minecraft:pink_stained_glass": {
                    "Color": "#80D95687",
                    "LightLevel": 0,
                    "DisplayName": "Pink Stained Glass"
                },
                "minecraft:gray_stained_glass": {
                    "Color": "#809B9B9B",
                    "LightLevel": 0,
                    "DisplayName": "Gray Stained Glass"
                },
                "minecraft:light_gray_stained_glass": {
                    "Color": "#807C7C76",
                    "LightLevel": 0,
                    "DisplayName": "Light Gray Stained Glass"
                },
                "minecraft:cyan_stained_glass": {
                    "Color": "#80048EA5",
                    "LightLevel": 0,
                    "DisplayName": "Cyan Stained Glass"
                },
                "minecraft:purple_stained_glass": {
                    "Color": "#80701AB6",
                    "LightLevel": 0,
                    "DisplayName": "Purple Stained Glass"
                },
                "minecraft:blue_stained_glass": {
                    "Color": "#802F32AF",
                    "LightLevel": 0,
                    "DisplayName": "Blue Stained Glass"
                },
                "minecraft:brown_stained_glass": {
                    "Color": "#8077451E",
                    "LightLevel": 0,
                    "DisplayName": "Brown Stained Glass"
                },
                "minecraft:green_stained_glass": {
                    "Color": "#80597323",
                    "LightLevel": 0,
                    "DisplayName": "Green Stained Glass"
                },
                "minecraft:red_stained_glass": {
                    "Color": "#80AD1D1D",
                    "LightLevel": 0,
                    "DisplayName": "Red Stained Glass"
                },
                "minecraft:black_stained_glass": {
                    "Color": "#80424242",
                    "LightLevel": 0,
                    "DisplayName": "Black Stained Glass"
                },
                "minecraft:oak_planks": {
                    "Color": "#FF937840",
                    "LightLevel": 0,
                    "DisplayName": "Oak Planks"
                },
                "minecraft:spruce_planks": {
                    "Color": "#FF654523",
                    "LightLevel": 0,
                    "DisplayName": "SprucePlanks"
                },
                "minecraft:birch_planks": {
                    "Color": "#FFB09A5E",
                    "LightLevel": 0,
                    "DisplayName": "Birch Planks"
                },
                "minecraft:jungle_planks": {
                    "Color": "#FF956440",
                    "LightLevel": 0,
                    "DisplayName": "Jungle Planks"
                },
                "minecraft:acacia_planks": {
                    "Color": "#FFA14F22",
                    "LightLevel": 0,
                    "DisplayName": "Acacia Planks"
                },
                "minecraft:dark_oak_planks": {
                    "Color": "#FF3E240C",
                    "LightLevel": 0,
                    "DisplayName": "Dark Oak Planks"
                },
                "minecraft:crimson_planks": {
                    "Color": "#FF5B243B",
                    "LightLevel": 0,
                    "DisplayName": "Crimson Planks"
                },
                "minecraft:warped_planks": {
                    "Color": "#FF1B5B56",
                    "LightLevel": 0,
                    "DisplayName": "Warped Planks"
                },
                "minecraft:oak_log": {
                    "Color": "#FF634D2D",
                    "LightLevel": 0,
                    "DisplayName": "Oak Log"
                },
                "minecraft:spruce_log": {
                    "Color": "#FF231200",
                    "LightLevel": 0,
                    "DisplayName": "Spruce Log"
                },
                "minecraft:birch_log ": {
                    "Color": "#FFB4BAB1",
                    "LightLevel": 0,
                    "DisplayName": "Birch Log"
                },
                "minecraft:jungle_log": {
                    "Color": "#FF4A360B",
                    "LightLevel": 0,
                    "DisplayName": "Jungle Log"
                },
                "minecraft:acacia_log": {
                    "Color": "#FF4A360B",
                    "LightLevel": 0,
                    "DisplayName": "Acacia Log"
                },
                "minecraft:dark_oak_log": {
                    "Color": "#FF2B1F0D",
                    "LightLevel": 0,
                    "DisplayName": "Dark Oak Log"
                },
                "minecraft:crimson_stem": {
                    "Color": "#FF6B2943",
                    "LightLevel": 0,
                    "DisplayName": "Crimson Stem"
                },
                "minecraft:warped_stem": {
                    "Color": "#FF1F6D69",
                    "LightLevel": 0,
                    "DisplayName": "Warped Stem"
                },
                "minecraft:stripped_oak_log": {
                    "Color": "#FF937840",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Oak Log"
                },
                "minecraft:stripped_spruce_log": {
                    "Color": "#FF231200",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Spruce Log"
                },
                "minecraft:stripped_birch_log": {
                    "Color": "#FFB4BAB1",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Birch Log"
                },
                "minecraft:stripped_jungle_log": {
                    "Color": "#FF4A360B",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Jungle Log"
                },
                "minecraft:stripped_acacia_log": {
                    "Color": "#FFA14F22",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Acacia Log"
                },
                "minecraft:stripped_dark_oak_log": {
                    "Color": "#FF2B1F0D",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Dark Oak Log"
                },
                "minecraft:stripped_crimson_stem": {
                    "Color": "#FF6B2943",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Crimson Stem"
                },
                "minecraft:stripped_warped_stem": {
                    "Color": "#FF1F6D69",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Warped Stem"
                },
                "minecraft:stripped_oak_wood": {
                    "Color": "#FF937840",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Oak Wood"
                },
                "minecraft:stripped_spruce_wood": {
                    "Color": "#FF231200",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Spruce Wood"
                },
                "minecraft:stripped_birch_wood": {
                    "Color": "#FFB4BAB1",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Birch Wood"
                },
                "minecraft:stripped_jungle_wood": {
                    "Color": "#FF4A360B",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Jungle Wood"
                },
                "minecraft:stripped_acacia_wood": {
                    "Color": "#FFA14F22",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Acacia Wood"
                },
                "minecraft:stripped_dark_oak_wood": {
                    "Color": "#FF2B1F0D",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Dark Oak Wood"
                },
                "minecraft:stripped_crimson_hyphae": {
                    "Color": "#FF6B2943",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Crimson Hyphae"
                },
                "minecraft:stripped_warped_hyphae": {
                    "Color": "#FF1F6D69",
                    "LightLevel": 0,
                    "DisplayName": "Stripped Warped Hyphae"
                },
                "minecraft:oak_wood": {
                    "Color": "#FF634D2D",
                    "LightLevel": 0,
                    "DisplayName": "Oak Wood"
                },
                "minecraft:spruce_wood": {
                    "Color": "#FF231200",
                    "LightLevel": 0,
                    "DisplayName": "Spruce Wood"
                },
                "minecraft:birch_wood": {
                    "Color": "#FFB4BAB1",
                    "LightLevel": 0,
                    "DisplayName": "Birch Wood"
                },
                "minecraft:jungle_wood": {
                    "Color": "#FF4A360B",
                    "LightLevel": 0,
                    "DisplayName": "Jungle Wood"
                },
                "minecraft:acacia_wood": {
                    "Color": "#FF4A360B",
                    "LightLevel": 0,
                    "DisplayName": "Acacia Wood"
                },
                "minecraft:dark_oak_wood": {
                    "Color": "#FF2B1F0D",
                    "LightLevel": 0,
                    "DisplayName": "Dark Oak Wood"
                },
                "minecraft:crimson_hyphae": {
                    "Color": "#FF6B2943",
                    "LightLevel": 0,
                    "DisplayName": "Crimson Hyphae"
                },
                "minecraft:warped_hyphae": {
                    "Color": "#FF1F6D69",
                    "LightLevel": 0,
                    "DisplayName": "Warped Hyphae"
                },
                "minecraft:nether_wart_block": {
                    "Color": "#FF74090A",
                    "LightLevel": 0,
                    "DisplayName": "Nether Wart Block"
                },
                "minecraft:warped_wart_block": {
                    "Color": "#FF046767",
                    "LightLevel": 0,
                    "DisplayName": "Warped Wart Block"
                },
                "minecraft:stone_slab": {
                    "Color": "#FF737373",
                    "LightLevel": 0,
                    "DisplayName": "Stone Slab"
                },
                "minecraft:smooth_stone_slab": {
                    "Color": "#FF808080",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Stone Slab"
                },
                "minecraft:stone_brick_slab": {
                    "Color": "#FF606060",
                    "LightLevel": 0,
                    "DisplayName": "Stone Brick Slab"
                },
                "minecraft:mossy_stone_brick_slab": {
                    "Color": "#FF4C6056",
                    "LightLevel": 0,
                    "DisplayName": "Mossy Stone Brick Slab"
                },
                "minecraft:cobblestone_slab": {
                    "Color": "#FF797979",
                    "LightLevel": 0,
                    "DisplayName": "Cobblestone Slab"
                },
                "minecraft:granite_slab": {
                    "Color": "#FF8D5B48",
                    "LightLevel": 0,
                    "DisplayName": "Granite Slab"
                },
                "minecraft:diorite_slab": {
                    "Color": "#FF7B7B7E",
                    "LightLevel": 0,
                    "DisplayName": "Diorite Slab"
                },
                "minecraft:andesite_slab": {
                    "Color": "#FF656569",
                    "LightLevel": 0,
                    "DisplayName": "Andesite Slab"
                },
                "minecraft:polished_granite_slab": {
                    "Color": "#FF8D5B48",
                    "LightLevel": 0,
                    "DisplayName": "Polished Granite Slab"
                },
                "minecraft:polished_diorite_slab": {
                    "Color": "#FF656565",
                    "LightLevel": 0,
                    "DisplayName": "Polished Diorite Slab"
                },
                "minecraft:polished_andesite_slab": {
                    "Color": "#FFA0A0A0",
                    "LightLevel": 0,
                    "DisplayName": "Polished Andesite Slab"
                },
                "minecraft:sandstone_slab": {
                    "Color": "#FFB5AD7B",
                    "LightLevel": 0,
                    "DisplayName": "Sandstone Slab"
                },
                "minecraft:smooth_sandstone_slab": {
                    "Color": "#FFB5AD7B",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Sandstone Slab"
                },
                "minecraft:cut_sandstone_slab": {
                    "Color": "#FFB5AD7B",
                    "LightLevel": 0,
                    "DisplayName": "Cut Sandstone Slab"
                },
                "minecraft:red_sandstone_slab": {
                    "Color": "#FF833906",
                    "LightLevel": 0,
                    "DisplayName": "Red Sandstone Slab"
                },
                "minecraft:smooth_red_sandstone_slab": {
                    "Color": "#FF833906",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Red Sandstone Slab"
                },
                "minecraft:cut_red_sandstone_slab": {
                    "Color": "#FF833906",
                    "LightLevel": 0,
                    "DisplayName": "Cut Red Sandstone Slab"
                },
                "minecraft:brick_slab": {
                    "Color": "#FF83402D",
                    "LightLevel": 0,
                    "DisplayName": "Brick Slab"
                },
                "minecraft:nether_brick_slab": {
                    "Color": "#FF2B1015",
                    "LightLevel": 0,
                    "DisplayName": "Nether Brick Slab"
                },
                "minecraft:red_nether_brick_slab": {
                    "Color": "#FF410103",
                    "LightLevel": 0,
                    "DisplayName": "Red Nether Brick Slab"
                },
                "minecraft:quartz_slab": {
                    "Color": "#FFB3B0AA",
                    "LightLevel": 0,
                    "DisplayName": "Quartz Slab"
                },
                "minecraft:smooth_quartz_slab ": {
                    "Color": "#FFB3B0AA",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Quartz Slab"
                },
                "minecraft:prismarine_slab": {
                    "Color": "#FF5BA296",
                    "LightLevel": 0,
                    "DisplayName": "Prismarine Slab"
                },
                "minecraft:prismarine_brick_slab": {
                    "Color": "#FF4B8778",
                    "LightLevel": 0,
                    "DisplayName": "Prismarine Brick Slab"
                },
                "minecraft:dark_prismarine_slab": {
                    "Color": "#FF244E3D",
                    "LightLevel": 0,
                    "DisplayName": "Dark Prismarine Slab"
                },
                "minecraft:cobbled_deepslate_slab": {
                    "Color": "#FF3C3C3C",
                    "LightLevel": 0,
                    "DisplayName": "Cobbled Deepslate Slab"
                },
                "minecraft:polished_deepslate_slab": {
                    "Color": "#FF3C3C3C",
                    "LightLevel": 0,
                    "DisplayName": "Polished Deepslate Slab"
                },
                "minecraft:deepslate_brick_slab": {
                    "Color": "#FF3C3C3C",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Brick Slab"
                },
                "minecraft:deepslate_tile_slab": {
                    "Color": "#FF3C3C3C",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Tile Slab"
                },
                "minecraft:end_stone_brick_slab": {
                    "Color": "#FFCBCD97",
                    "LightLevel": 0,
                    "DisplayName": "End Stone Brick Slab"
                },
                "minecraft:purpur_slab": {
                    "Color": "#FF8A5E8A",
                    "LightLevel": 0,
                    "DisplayName": "Purpur Slab"
                },
                "minecraft:blackstone_slab": {
                    "Color": "#FF241F26",
                    "LightLevel": 0,
                    "DisplayName": "Blackstone Slab"
                },
                "minecraft:polished_blackstone_slab": {
                    "Color": "#FF241F26",
                    "LightLevel": 0,
                    "DisplayName": "Polished Blackstone Slab"
                },
                "minecraft:polished_blackstone_brick_slab": {
                    "Color": "#FF241F26",
                    "LightLevel": 0,
                    "DisplayName": "Polished Blackstone Brick Slab"
                },
                "minecraft:cut_copper_slab": {
                    "Color": "#FFA75237",
                    "LightLevel": 0,
                    "DisplayName": "Cut Copper Slab"
                },
                "minecraft:exposed_cut_copper_slab": {
                    "Color": "#FF9A7560",
                    "LightLevel": 0,
                    "DisplayName": "Exposed Cut Copper Slab"
                },
                "minecraft:weathered_cut_copper_slab": {
                    "Color": "#FF547853",
                    "LightLevel": 0,
                    "DisplayName": "Weathered Cut Copper Slab"
                },
                "minecraft:oxidized_cut_copper_slab": {
                    "Color": "#FF38896B",
                    "LightLevel": 0,
                    "DisplayName": "Oxidized Cut Copper Slab"
                },
                "minecraft:waxed_cut_copper_slab": {
                    "Color": "#FFA75237",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Cut Copper Slab"
                },
                "minecraft:waxed_exposed_cut_copper_slab": {
                    "Color": "#FF9A7560",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Exposed Cut Copper Slab"
                },
                "minecraft:waxed_weathered_cut_copper_slab": {
                    "Color": "#FF547853",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Weathered Cut Copper Slab"
                },
                "minecraft:waxed_oxidized_cut_copper_slab": {
                    "Color": "#FF38896B",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Oxidized Cut Copper Slab"
                },
                "minecraft:petrified_oak_slab": {
                    "Color": "#FF937840",
                    "LightLevel": 0,
                    "DisplayName": "Petrified Oak Slab"
                },
                "minecraft:oak_slab": {
                    "Color": "#FF937840",
                    "LightLevel": 0,
                    "DisplayName": "Oak Slab"
                },
                "minecraft:spruce_slab": {
                    "Color": "#FF654523",
                    "LightLevel": 0,
                    "DisplayName": "Spruce Slab"
                },
                "minecraft:birch_slab": {
                    "Color": "#FFB09A5E",
                    "LightLevel": 0,
                    "DisplayName": "Birch Slab"
                },
                "minecraft:jungle_slab": {
                    "Color": "#FF956440",
                    "LightLevel": 0,
                    "DisplayName": "Jungle Slab"
                },
                "minecraft:acacia_slab": {
                    "Color": "#FFA14F22",
                    "LightLevel": 0,
                    "DisplayName": "Acacia Slab"
                },
                "minecraft:dark_oak_slab": {
                    "Color": "#FF3E240C",
                    "LightLevel": 0,
                    "DisplayName": "Dark Oak Slab"
                },
                "minecraft:crimson_slab": {
                    "Color": "#FF5B243B",
                    "LightLevel": 0,
                    "DisplayName": "Crimson Slab"
                },
                "minecraft:warped_slab": {
                    "Color": "#FF1B5B56",
                    "LightLevel": 0,
                    "DisplayName": "Warped Slab"
                },
                "minecraft:stone_stairs": {
                    "Color": "#FF737373",
                    "LightLevel": 0,
                    "DisplayName": "Stone Stairs"
                },
                "minecraft:stone_brick_stairs": {
                    "Color": "#FF606060",
                    "LightLevel": 0,
                    "DisplayName": "Stone Brick Stairs"
                },
                "minecraft:mossy_stone_brick_stairs": {
                    "Color": "#FF4C6056",
                    "LightLevel": 0,
                    "DisplayName": "Mossy Stone Brick Stairs"
                },
                "minecraft:cobblestone_stairs": {
                    "Color": "#FF797979",
                    "LightLevel": 0,
                    "DisplayName": "Cobblestone Stairs"
                },
                "minecraft:mossy_cobblestone_stairs": {
                    "Color": "#FF65796B",
                    "LightLevel": 0,
                    "DisplayName": "Mossy Cobblestone Stairs"
                },
                "minecraft:granite_stairs": {
                    "Color": "#FF8D5B48",
                    "LightLevel": 0,
                    "DisplayName": "Granite Stairs"
                },
                "minecraft:andesite_stairs": {
                    "Color": "#FF656565",
                    "LightLevel": 0,
                    "DisplayName": "Andesite Stairs"
                },
                "minecraft:diorite_stairs": {
                    "Color": "#FFA0A0A0",
                    "LightLevel": 0,
                    "DisplayName": "Diorite Stairs"
                },
                "minecraft:polished_granite_stairs": {
                    "Color": "#FF8D5B48",
                    "LightLevel": 0,
                    "DisplayName": "Polished Granite Stairs"
                },
                "minecraft:polished_andesite_stairs": {
                    "Color": "#FF656565",
                    "LightLevel": 0,
                    "DisplayName": "Polished Andesite Stairs"
                },
                "minecraft:polished_diorite_stairs": {
                    "Color": "#FFA0A0A0",
                    "LightLevel": 0,
                    "DisplayName": "Polished Diorite Stairs"
                },
                "minecraft:cobbled_deepslate_stairs": {
                    "Color": "#FF535353",
                    "LightLevel": 0,
                    "DisplayName": "Cobbled Deepslate Stairs"
                },
                "minecraft:polished_deepslate_stairs": {
                    "Color": "#FF535353",
                    "LightLevel": 0,
                    "DisplayName": "Polished Deepslate Stairs"
                },
                "minecraft:deepslate_brick_stairs": {
                    "Color": "#FF4C4C4C",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Brick Stairs"
                },
                "minecraft:deepslate_tile_stairs": {
                    "Color": "#FF2D2D2E",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Tile Stairs"
                },
                "minecraft:brick_stairs": {
                    "Color": "#FF83402D",
                    "LightLevel": 0,
                    "DisplayName": "Brick Stairs"
                },
                "minecraft:sandstone_stairs": {
                    "Color": "#FFB5AD7B",
                    "LightLevel": 0,
                    "DisplayName": "Sandstone Stairs"
                },
                "minecraft:smooth_sandstone_stairs": {
                    "Color": "#FFB5AD7B",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Sandstone Stairs"
                },
                "minecraft:red_sandstone_stairs": {
                    "Color": "#FF833906",
                    "LightLevel": 0,
                    "DisplayName": "Red Sandstone Stairs"
                },
                "minecraft:smooth_red_sandstone_stairs": {
                    "Color": "#FF833906",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Red Sandstone Stairs"
                },
                "minecraft:nether_brick_stairs": {
                    "Color": "#FF2B1015",
                    "LightLevel": 0,
                    "DisplayName": "Nether Brick Stairs"
                },
                "minecraft:red_nether_brick_stairs": {
                    "Color": "#FF410103",
                    "LightLevel": 0,
                    "DisplayName": "Red Nether Brick Stairs"
                },
                "minecraft:quartz_stairs": {
                    "Color": "#FFB3B0AA",
                    "LightLevel": 0,
                    "DisplayName": "Quartz Stairs"
                },
                "minecraft:smooth_quartz_stairs": {
                    "Color": "#FFD1CEC8",
                    "LightLevel": 0,
                    "DisplayName": "Smooth Quartz Stairs"
                },
                "minecraft:blackstone_stairs": {
                    "Color": "#FF2A252C",
                    "LightLevel": 0,
                    "DisplayName": "Blackstone Stairs"
                },
                "minecraft:polished_blackstone_stairs": {
                    "Color": "#FF2A252C",
                    "LightLevel": 0,
                    "DisplayName": "Polished Blackstone Stairs"
                },
                "minecraft:polished_blackstone_brick_stairs": {
                    "Color": "#FF3E3641",
                    "LightLevel": 0,
                    "DisplayName": "Polished Blackstone Brick Stairs"
                },
                "minecraft:end_stone_brick_stairs": {
                    "Color": "#FFCBCD97",
                    "LightLevel": 0,
                    "DisplayName": "End Stone Stairs"
                },
                "minecraft:purpur_stairs": {
                    "Color": "#FF8A5E8A",
                    "LightLevel": 0,
                    "DisplayName": "Purpur Stairs"
                },
                "minecraft:prismarine_stairs": {
                    "Color": "#FF5DA28C",
                    "LightLevel": 0,
                    "DisplayName": "Prismarine Stairs"
                },
                "minecraft:prismarine_brick_stairs": {
                    "Color": "#FF78B5A6",
                    "LightLevel": 0,
                    "DisplayName": "Prismarine Brick Stairs"
                },
                "minecraft:dark_prismarine_stairs": {
                    "Color": "#FF244E3D",
                    "LightLevel": 0,
                    "DisplayName": "Dark Prismarine Stairs"
                },
                "minecraft:cut_copper_stairs": {
                    "Color": "#FFA75237",
                    "LightLevel": 0,
                    "DisplayName": "Cut Copper Stairs"
                },
                "minecraft:exposed_cut_copper_stairs": {
                    "Color": "#FF9A7560",
                    "LightLevel": 0,
                    "DisplayName": "Exposed Cut Copper Stairs"
                },
                "minecraft:weathered_cut_copper_stairs": {
                    "Color": "#FF547853",
                    "LightLevel": 0,
                    "DisplayName": "WeatheredCut Copper Stairs"
                },
                "minecraft:oxidized_cut_copper_stairs": {
                    "Color": "#FF38896B",
                    "LightLevel": 0,
                    "DisplayName": "Oxidized Cut Copper Stairs"
                },
                "minecraft:waxed_cut_copper_stairs": {
                    "Color": "#FFA75237",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Cut Copper Stairs"
                },
                "minecraft:waxed_exposed_cut_copper_stairs": {
                    "Color": "#FF9A7560",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Exposed Cut Copper Stairs"
                },
                "minecraft:waxed_weathered_cut_copper_stairs": {
                    "Color": "#FF547853",
                    "LightLevel": 0,
                    "DisplayName": "Waxed WeatheredCut Copper Stairs"
                },
                "minecraft:waxed_oxidized_cut_copper_stairs": {
                    "Color": "#FF38896B",
                    "LightLevel": 0,
                    "DisplayName": "Waxed Oxidized Cut Copper Stairs"
                },
                "minecraft:oak_stairs": {
                    "Color": "#FF937840",
                    "LightLevel": 0,
                    "DisplayName": "Oak Stairs"
                },
                "minecraft:acacia_stairs": {
                    "Color": "#FF654523",
                    "LightLevel": 0,
                    "DisplayName": "Spruce Stairs"
                },
                "minecraft:dark_oak_stairs": {
                    "Color": "#FFB09A5E",
                    "LightLevel": 0,
                    "DisplayName": "Birch Stairs"
                },
                "minecraft:spruce_stairs": {
                    "Color": "#FF956440",
                    "LightLevel": 0,
                    "DisplayName": "Jungle Stairs"
                },
                "minecraft:birch_stairs": {
                    "Color": "#FFA14F22",
                    "LightLevel": 0,
                    "DisplayName": "Acacia Stairs"
                },
                "minecraft:jungle_stairs": {
                    "Color": "#FF3E240C",
                    "LightLevel": 0,
                    "DisplayName": "Dark Stairs"
                },
                "minecraft:crimson_stairs": {
                    "Color": "#FF5B243B",
                    "LightLevel": 0,
                    "DisplayName": "Crimson Stairs"
                },
                "minecraft:warped_stairs": {
                    "Color": "#FF1B5B56",
                    "LightLevel": 0,
                    "DisplayName": "Warped Stairs"
                },
                "minecraft:ice": {
                    "Color": "#8071A0F2",
                    "LightLevel": 0,
                    "DisplayName": "Ice"
                },
                "minecraft:packed_ice": {
                    "Color": "#FF71A0F2",
                    "LightLevel": 0,
                    "DisplayName": "Packed Ice"
                },
                "minecraft:blue_ice": {
                    "Color": "#FF5487DC",
                    "LightLevel": 0,
                    "DisplayName": "Blue Ice"
                },
                "minecraft:snow_block": {
                    "Color": "#FFBFC8C8",
                    "LightLevel": 0,
                    "DisplayName": "Snow Block"
                },
                "minecraft:pumpkin": {
                    "Color": "#FFB76D0C",
                    "LightLevel": 0,
                    "DisplayName": "Pumpkin"
                },
                "minecraft:carved_pumpkin": {
                    "Color": "#FFA65C00",
                    "LightLevel": 0,
                    "DisplayName": "Carved Pumpkin"
                },
                "minecraft:jack_o_lantern": {
                    "Color": "#FFC59000",
                    "LightLevel": 14,
                    "DisplayName": "Jack O Lantern"
                },
                "minecraft:hay_block": {
                    "Color": "#FFAB8D02",
                    "LightLevel": 0,
                    "DisplayName": "Hay Bale"
                },
                "minecraft:bone_block": {
                    "Color": "#FFB5B19D",
                    "LightLevel": 0,
                    "DisplayName": "Bone Block"
                },
                "minecraft:melon": {
                    "Color": "#FF8E8D07",
                    "LightLevel": 0,
                    "DisplayName": "Melon"
                },
                "minecraft:bookshelf": {
                    "Color": "#FF654625",
                    "LightLevel": 0,
                    "DisplayName": "Bookshelf"
                },
                "minecraft:oak_sapling": {
                    "Color": "#FF607F0E",
                    "LightLevel": 0,
                    "DisplayName": "Oak Sapling"
                },
                "minecraft:spruce_sapling": {
                    "Color": "#FF607F0E",
                    "LightLevel": 0,
                    "DisplayName": "Spruce Sapling"
                },
                "minecraft:birch_sapling": {
                    "Color": "#FF607F0E",
                    "LightLevel": 0,
                    "DisplayName": "Birch Sapling"
                },
                "minecraft:jungle_sapling": {
                    "Color": "#FF607F0E",
                    "LightLevel": 0,
                    "DisplayName": "Jungle Sapling"
                },
                "minecraft:acacia_sapling": {
                    "Color": "#FF607F0E",
                    "LightLevel": 0,
                    "DisplayName": "Acacia Sapling"
                },
                "minecraft:dark_oak_sapling": {
                    "Color": "#FF607F0E",
                    "LightLevel": 0,
                    "DisplayName": "Dark Oak Sapling"
                },
                "minecraft:oak_leaves": {
                    "Color": "#FF337814",
                    "LightLevel": 0,
                    "DisplayName": " Oak Leaves"
                },
                "minecraft:spruce_leaves": {
                    "Color": "#FF2C512C",
                    "LightLevel": 0,
                    "DisplayName": " Spruce Leaves"
                },
                "minecraft:birch_leaves": {
                    "Color": "#FF52742D",
                    "LightLevel": 0,
                    "DisplayName": " Birch Leaves"
                },
                "minecraft:jungle_leaves": {
                    "Color": "#FF2C9300",
                    "LightLevel": 0,
                    "DisplayName": " Jungle Leaves"
                },
                "minecraft:acacia_leaves": {
                    "Color": "#FF268300",
                    "LightLevel": 0,
                    "DisplayName": " Acacia Leaves"
                },
                "minecraft:dark_oak_leaves": {
                    "Color": "#FF1B5E00",
                    "LightLevel": 0,
                    "DisplayName": " Dark Oak Leaves"
                },
                "minecraft:azalea_leaves": {
                    "Color": "#FF486117",
                    "LightLevel": 0,
                    "DisplayName": " Azalea Leaves"
                },
                "minecraft:flowering_azalea_leaves": {
                    "Color": "#FF555C3C",
                    "LightLevel": 0,
                    "DisplayName": "Flowering Azalea Leaves"
                },
                "minecraft:cobweb": {
                    "Color": "#FFDEDEDE",
                    "LightLevel": 0,
                    "DisplayName": "Cobweb"
                },
                "minecraft:grass": {
                    "Color": "#FF81B24C",
                    "LightLevel": 0,
                    "DisplayName": "Grass"
                },
                "minecraft:fern": {
                    "Color": "#FF557C2B",
                    "LightLevel": 0,
                    "DisplayName": "Fern"
                },
                "minecraft:dead_bush": {
                    "Color": "#FF7E4E12",
                    "LightLevel": 0,
                    "DisplayName": "Dead Bush"
                },
                "minecraft:seagrass": {
                    "Color": "#FF7E4E12",
                    "LightLevel": 0,
                    "DisplayName": "Seagrass"
                },
                "minecraft:tall_seagrass": {
                    "Color": "#FF7E4E12",
                    "LightLevel": 0,
                    "DisplayName": "Tall Seagrass"
                },
                "minecraft:sea_pickle": {
                    "Color": "#FF6B7129",
                    "LightLevel": 0,
                    "DisplayName": "Sea Pickle"
                },
                "minecraft:dandelion": {
                    "Color": "#FFC6D000",
                    "LightLevel": 0,
                    "DisplayName": "Dandelion"
                },
                "minecraft:poppy": {
                    "Color": "#FFBE0A00",
                    "LightLevel": 0,
                    "DisplayName": "Poppy"
                },
                "minecraft:blue_orchid": {
                    "Color": "#FF098EDC",
                    "LightLevel": 0,
                    "DisplayName": "Blue Orchid"
                },
                "minecraft:allium": {
                    "Color": "#FF9946DC",
                    "LightLevel": 0,
                    "DisplayName": "Allium"
                },
                "minecraft:azure_bluet": {
                    "Color": "#FFB2B8C0",
                    "LightLevel": 0,
                    "DisplayName": "Azure Bluet"
                },
                "minecraft:red_tulip": {
                    "Color": "#FFAF1800",
                    "LightLevel": 0,
                    "DisplayName": "Red Tulip"
                },
                "minecraft:orange_tulip": {
                    "Color": "#FFC35305",
                    "LightLevel": 0,
                    "DisplayName": "Orange Tulip"
                },
                "minecraft:white_tulip": {
                    "Color": "#FFB6B6B6",
                    "LightLevel": 0,
                    "DisplayName": "White Tulip"
                },
                "minecraft:pink_tulip": {
                    "Color": "#FFBD91BD",
                    "LightLevel": 0,
                    "DisplayName": "Pink Tulip"
                },
                "minecraft:cornflower": {
                    "Color": "#FF617FE5",
                    "LightLevel": 0,
                    "DisplayName": "Cornflower"
                },
                "minecraft:lily_of_the_valley": {
                    "Color": "#FFE4E4E4",
                    "LightLevel": 0,
                    "DisplayName": "Lily of The Valley"
                },
                "minecraft:wither_rose": {
                    "Color": "#FF23270F",
                    "LightLevel": 0,
                    "DisplayName": "Wither Rose"
                },
                "minecraft:sunflower": {
                    "Color": "#FFDCC511",
                    "LightLevel": 0,
                    "DisplayName": "Sunflower"
                },
                "minecraft:lilac": {
                    "Color": "#FF957899",
                    "LightLevel": 0,
                    "DisplayName": "Lilac"
                },
                "minecraft:rose_bush": {
                    "Color": "#FFE10E00",
                    "LightLevel": 0,
                    "DisplayName": "Rose Bush"
                },
                "minecraft:peony": {
                    "Color": "#FFB992CA",
                    "LightLevel": 0,
                    "DisplayName": "Peony"
                },
                "minecraft:tall_grass": {
                    "Color": "#FF6FA535",
                    "LightLevel": 0,
                    "DisplayName": "Tall Grash"
                },
                "minecraft:large_fern": {
                    "Color": "#FF6FA535",
                    "LightLevel": 0,
                    "DisplayName": "Large Fern"
                },
                "minecraft:azalea": {
                    "Color": "#FF5F7628",
                    "LightLevel": 0,
                    "DisplayName": "Azalea"
                },
                "minecraft:flowering_azalea": {
                    "Color": "#FF5F7628",
                    "LightLevel": 0,
                    "DisplayName": "Flowering Azalea"
                },
                "minecraft:spore_blossom": {
                    "Color": "#FF5F7628",
                    "LightLevel": 0,
                    "DisplayName": "Spore Blossom"
                },
                "minecraft:brown_mushroom": {
                    "Color": "#FF5F4533",
                    "LightLevel": 0,
                    "DisplayName": "Brown Mushroom"
                },
                "minecraft:red_mushroom ": {
                    "Color": "#FF9B0D0B",
                    "LightLevel": 0,
                    "DisplayName": "Red Mushroom"
                },
                "minecraft:crimson_fungus": {
                    "Color": "#FF8B2D19",
                    "LightLevel": 0,
                    "DisplayName": "Crimson Fungus"
                },
                "minecraft:warped_fungus": {
                    "Color": "#FF007969",
                    "LightLevel": 0,
                    "DisplayName": "Warped Fungus"
                },
                "minecraft:crimson_root": {
                    "Color": "#FF8B2D19",
                    "LightLevel": 0,
                    "DisplayName": "Crimson Root"
                },
                "minecraft:warped_roots": {
                    "Color": "#FF007969",
                    "LightLevel": 0,
                    "DisplayName": "Warped Root"
                },
                "minecraft:nether_sprouts": {
                    "Color": "#FF007969",
                    "LightLevel": 0,
                    "DisplayName": "Nether Sprouts"
                },
                "minecraft:weeping_vines": {
                    "Color": "#FF8B2D19",
                    "LightLevel": 0,
                    "DisplayName": "Weeping Vines"
                },
                "minecraft:twisting_vines": {
                    "Color": "#FF007969",
                    "LightLevel": 0,
                    "DisplayName": "Twisting Vines"
                },
                "minecraft:vine": {
                    "Color": "#FF356600",
                    "LightLevel": 0,
                    "DisplayName": "Vine"
                },
                "minecraft:glow_lichen": {
                    "Color": "#FF586A60",
                    "LightLevel": 7,
                    "DisplayName": "Glow Lichen"
                },
                "minecraft:lily_pad": {
                    "Color": "#FF1A782A",
                    "LightLevel": 0,
                    "DisplayName": "Lily Pad"
                },
                "minecraft:sugar_cane": {
                    "Color": "#FF698B45",
                    "LightLevel": 0,
                    "DisplayName": "Sugar Cane"
                },
                "minecraft:kelp": {
                    "Color": "#FF508926",
                    "LightLevel": 0,
                    "DisplayName": "Kelp"
                },
                "minecraft:moss_block": {
                    "Color": "#FF546827",
                    "LightLevel": 0,
                    "DisplayName": "Moss Block"
                },
                "minecraft:hanging_roots": {
                    "Color": "#FF895C47",
                    "LightLevel": 0,
                    "DisplayName": "Hanging Roots"
                },
                "minecraft:big_dripleaf": {
                    "Color": "#FF59781A",
                    "LightLevel": 0,
                    "DisplayName": "Big Dripleaf"
                },
                "minecraft:small_dripleaf": {
                    "Color": "#FF59781A",
                    "LightLevel": 0,
                    "DisplayName": "Small Dripleaf"
                },
                "minecraft:bamboo": {
                    "Color": "#FF607F0E",
                    "LightLevel": 0,
                    "DisplayName": "Bamboo"
                },
                "minecraft:torch": {
                    "Color": "#FFEDED00",
                    "LightLevel": 14,
                    "DisplayName": "Torch"
                },
                "minecraft:end_rod": {
                    "Color": "#FFCACACA",
                    "LightLevel": 14,
                    "DisplayName": "End Rod"
                },
                "minecraft:chorus_plant": {
                    "Color": "#FFAF77E5",
                    "LightLevel": 0,
                    "DisplayName": "Chorus Plant"
                },
                "minecraft:chorus_flower": {
                    "Color": "#FFAF77E5",
                    "LightLevel": 0,
                    "DisplayName": "Chorus Flower"
                },
                "minecraft:chest": {
                    "Color": "#FF98671B",
                    "LightLevel": 0,
                    "DisplayName": "Chest"
                },
                "minecraft:crafting_table": {
                    "Color": "#FF7B4D2B",
                    "LightLevel": 0,
                    "DisplayName": "Crafting Table"
                },
                "minecraft:furnace": {
                    "Color": "#FF5E5E5F",
                    "LightLevel": 0,
                    "DisplayName": "Furnace"
                },
                "minecraft:farmland": {
                    "Color": "#FF512B10",
                    "LightLevel": 0,
                    "DisplayName": "Farmland"
                },
                "minecraft:dirt_path": {
                    "Color": "#FF7D642E",
                    "LightLevel": 0,
                    "DisplayName": "Dirt Path"
                },
                "minecraft:ladder": {
                    "Color": "#FF7B4D2B",
                    "LightLevel": 0,
                    "DisplayName": "Ladder"
                },
                "minecraft:snow": {
                    "Color": "#FFDFE9E9",
                    "LightLevel": 0,
                    "DisplayName": "Snow"
                },
                "minecraft:cactus": {
                    "Color": "#FF085C13",
                    "LightLevel": 0,
                    "DisplayName": "Cactus"
                },
                "minecraft:jukebox": {
                    "Color": "#FF7B4D2B",
                    "LightLevel": 0,
                    "DisplayName": "Jukebox"
                },
                "minecraft:oak_fence": {
                    "Color": "#FF937840",
                    "LightLevel": 0,
                    "DisplayName": "Oak Fence"
                },
                "minecraft:spruce_fence": {
                    "Color": "#FF654523",
                    "LightLevel": 0,
                    "DisplayName": "Spruce Fence"
                },
                "minecraft:birch_fence": {
                    "Color": "#FFB09A5E",
                    "LightLevel": 0,
                    "DisplayName": "Birch Fence"
                },
                "minecraft:jungle_fence": {
                    "Color": "#FF956440",
                    "LightLevel": 0,
                    "DisplayName": "Jungle Fence"
                },
                "minecraft:acacia_fence": {
                    "Color": "#FFA14F22",
                    "LightLevel": 0,
                    "DisplayName": "Acacia Fence"
                },
                "minecraft:dark_oak_fence": {
                    "Color": "#FF3E240C",
                    "LightLevel": 0,
                    "DisplayName": "Dark Fence"
                },
                "minecraft:crimson_fence": {
                    "Color": "#FF5B243B",
                    "LightLevel": 0,
                    "DisplayName": "Crimson Fence"
                },
                "minecraft:warped_fence": {
                    "Color": "#FF1B5B56",
                    "LightLevel": 0,
                    "DisplayName": "Warped Fence"
                },
                "minecraft:infested_stone": {
                    "Color": "#FF737373",
                    "LightLevel": 0,
                    "DisplayName": "Infested Stone"
                },
                "minecraft:infested_cobblestone": {
                    "Color": "#FF797979",
                    "LightLevel": 0,
                    "DisplayName": "Infested Cobblestone"
                },
                "minecraft:infested_stone_bricks": {
                    "Color": "#FF606060",
                    "LightLevel": 0,
                    "DisplayName": "Infested Stone Bricks"
                },
                "minecraft:infested_mossy_stone_bricks": {
                    "Color": "#FF4C6056",
                    "LightLevel": 0,
                    "DisplayName": "Infested Mossy Stone Bricks"
                },
                "minecraft:infested_cracked_stone_bricks": {
                    "Color": "#FF606060",
                    "LightLevel": 0,
                    "DisplayName": "Infested Cracked Stone Bricks"
                },
                "minecraft:infested_chiseled_stone_bricks": {
                    "Color": "#FF606060",
                    "LightLevel": 0,
                    "DisplayName": "Infested Chiseled Stone Bricks"
                },
                "minecraft:infested_deepslate": {
                    "Color": "#FF535353",
                    "LightLevel": 0,
                    "DisplayName": "Infested Deepslate"
                },
                "minecraft:brown_mushroom_block": {
                    "Color": "#FF5F4533",
                    "LightLevel": 0,
                    "DisplayName": "Brown Mushroom Block"
                },
                "minecraft:red_mushroom_block": {
                    "Color": "#FF9B0D0B",
                    "LightLevel": 0,
                    "DisplayName": "Red Mushroom Block"
                },
                "minecraft:mushroom_stem": {
                    "Color": "#FFC5BFB2",
                    "LightLevel": 0,
                    "DisplayName": "Mushroom Stem"
                },
                "minecraft:iron_bars": {
                    "Color": "#FF828383",
                    "LightLevel": 0,
                    "DisplayName": "Iron Bars"
                },
                "minecraft:chain": {
                    "Color": "#FF3D4352",
                    "LightLevel": 0,
                    "DisplayName": "Chain"
                },
                "minecraft:enchanting_table": {
                    "Color": "#FFA02828",
                    "LightLevel": 8,
                    "DisplayName": "Enchanting Table"
                },
                "minecraft:end_portal_frame": {
                    "Color": "#FF376559",
                    "LightLevel": 2,
                    "DisplayName": "End Portal Frame"
                },
                "minecraft:ender_chest": {
                    "Color": "#FF253638",
                    "LightLevel": 10,
                    "DisplayName": "Ender Chest"
                },
                "minecraft:cobblestone_wall": {
                    "Color": "#FF797979",
                    "LightLevel": 0,
                    "DisplayName": "Cobblestone Wall"
                },
                "minecraft:mossy_cobblestone_wall": {
                    "Color": "#FF65796B",
                    "LightLevel": 0,
                    "DisplayName": "Mossy Cobblestone Wall"
                },
                "minecraft:brick_wall": {
                    "Color": "#FF83402D",
                    "LightLevel": 0,
                    "DisplayName": "Brick Wall"
                },
                "minecraft:stone_brick_wall": {
                    "Color": "#FF606060",
                    "LightLevel": 0,
                    "DisplayName": "Stone Brick Wall"
                },
                "minecraft:mossy_stone_brick_wall": {
                    "Color": "#FF4C6056",
                    "LightLevel": 0,
                    "DisplayName": "Mossy Stone Brick Wall"
                },
                "minecraft:granite_wall": {
                    "Color": "#FF8D5B48",
                    "LightLevel": 0,
                    "DisplayName": "Granite Wall"
                },
                "minecraft:andesite_wall": {
                    "Color": "#FF656565",
                    "LightLevel": 0,
                    "DisplayName": "Andesite Wall"
                },
                "minecraft:diorite_wall": {
                    "Color": "#FFA0A0A0",
                    "LightLevel": 0,
                    "DisplayName": "Diorite Wall"
                },
                "minecraft:nether_brick_wall": {
                    "Color": "#FF2B1015",
                    "LightLevel": 0,
                    "DisplayName": "Nether Brick Wall"
                },
                "minecraft:red_nether_brick_wall": {
                    "Color": "#FF410103",
                    "LightLevel": 0,
                    "DisplayName": "Red Nether Brick Wall"
                },
                "minecraft:blackstone_wall": {
                    "Color": "#FF2A252C",
                    "LightLevel": 0,
                    "DisplayName": "Blackstone Wall"
                },
                "minecraft:polished_blackstone_wall": {
                    "Color": "#FF2A252C",
                    "LightLevel": 0,
                    "DisplayName": "Polished Blackstone Wall"
                },
                "minecraft:polished_blackstone_brick_wall": {
                    "Color": "#FF2A252C",
                    "LightLevel": 0,
                    "DisplayName": "Polished Blackstone Brick Wall"
                },
                "minecraft:cobbled_deepslate_wall": {
                    "Color": "#FF535353",
                    "LightLevel": 0,
                    "DisplayName": "Cobbled Deepslate Wall"
                },
                "minecraft:polished_deepslate_wall": {
                    "Color": "#FF535353",
                    "LightLevel": 0,
                    "DisplayName": "Polished Deepslate Wall"
                },
                "minecraft:deepslate_brick_wall": {
                    "Color": "#FF4C4C4C",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Brick Wall"
                },
                "minecraft:deepslate_tile_wall": {
                    "Color": "#FF2D2D2E",
                    "LightLevel": 0,
                    "DisplayName": "Deepslate Tile Wall"
                },
                "minecraft:sandstone_wall": {
                    "Color": "#FFB5AD7B",
                    "LightLevel": 0,
                    "DisplayName": "Sandstone Wall"
                },
                "minecraft:red_sandstone_wall": {
                    "Color": "#FF833906",
                    "LightLevel": 0,
                    "DisplayName": "Red Sandstone Wall"
                },
                "minecraft:prismarine_wall": {
                    "Color": "#FF5DA28C",
                    "LightLevel": 0,
                    "DisplayName": "Prismarine Wall"
                },
                "minecraft:end_stone_brick_wall": {
                    "Color": "#FFCBCD97",
                    "LightLevel": 0,
                    "DisplayName": "End Stone Brick Wall"
                },
                "minecraft:anvil": {
                    "Color": "#FF3B3B3B",
                    "LightLevel": 0,
                    "DisplayName": "Anvil"
                },
                "minecraft:chipped_anvil": {
                    "Color": "#FF3B3B3B",
                    "LightLevel": 0,
                    "DisplayName": "Chipped Anvil"
                },
                "minecraft:damaged_anvil": {
                    "Color": "#FF3B3B3B",
                    "LightLevel": 0,
                    "DisplayName": "Damaged Anvil"
                },
                "minecraft:glass_pane": {
                    "Color": "#80A6CED6",
                    "LightLevel": 0,
                    "DisplayName": "Glass Pane"
                },
                "minecraft:white_stained_glass_pane": {
                    "Color": "#80E3E3E3",
                    "LightLevel": 0,
                    "DisplayName": "White Stained Glass Pane"
                },
                "minecraft:orange_stained_glass_pane": {
                    "Color": "#80E35300",
                    "LightLevel": 0,
                    "DisplayName": "Orange Stained Glass Pane"
                },
                "minecraft:magenta_stained_glass_pane": {
                    "Color": "#80BC26AF",
                    "LightLevel": 0,
                    "DisplayName": "Magenta Stained Glass Pane"
                },
                "minecraft:light_blue_stained_glass_pane": {
                    "Color": "#801288D0",
                    "LightLevel": 0,
                    "DisplayName": "Light Blue Stained Glass Pane"
                },
                "minecraft:yellow_stained_glass_pane": {
                    "Color": "#80E89E00",
                    "LightLevel": 0,
                    "DisplayName": "Yellow Stained Glass Pane"
                },
                "minecraft:lime_stained_glass_pane": {
                    "Color": "#8058B600",
                    "LightLevel": 0,
                    "DisplayName": "Lime Stained Glass Pane"
                },
                "minecraft:pink_stained_glass_pane": {
                    "Color": "#80D95687",
                    "LightLevel": 0,
                    "DisplayName": "Pink Stained Glass Pane"
                },
                "minecraft:gray_stained_glass_pane": {
                    "Color": "#809B9B9B",
                    "LightLevel": 0,
                    "DisplayName": "Gray Stained Glass Pane"
                },
                "minecraft:light_gray_stained_glass_pane": {
                    "Color": "#807C7C76",
                    "LightLevel": 0,
                    "DisplayName": "Light Gray Stained Glass Pane"
                },
                "minecraft:cyan_stained_glass_pane": {
                    "Color": "#80048EA5",
                    "LightLevel": 0,
                    "DisplayName": "Cyan Stained Glass Pane"
                },
                "minecraft:purple_stained_glass_pane": {
                    "Color": "#80701AB6",
                    "LightLevel": 0,
                    "DisplayName": "Purple Stained Glass Pane"
                },
                "minecraft:blue_stained_glass_pane": {
                    "Color": "#802F32AF",
                    "LightLevel": 0,
                    "DisplayName": "Blue Stained Glass Pane"
                },
                "minecraft:brown_stained_glass_pane": {
                    "Color": "#8077451E",
                    "LightLevel": 0,
                    "DisplayName": "Brown Stained Glass Pane"
                },
                "minecraft:green_stained_glass_pane": {
                    "Color": "#80597323",
                    "LightLevel": 0,
                    "DisplayName": "Green Stained Glass Pane"
                },
                "minecraft:red_stained_glass_pane": {
                    "Color": "#80AD1D1D",
                    "LightLevel": 0,
                    "DisplayName": "Red Stained Glass Pane"
                },
                "minecraft:black_stained_glass_pane": {
                    "Color": "#80424242",
                    "LightLevel": 0,
                    "DisplayName": "Black Stained Glass Pane"
                },
                "minecraft:shulker_box": {
                    "Color": "#FF845984",
                    "LightLevel": 0,
                    "DisplayName": "Shulker Box"
                },
                "minecraft:white_shulker_box": {
                    "Color": "#FFACB1B2",
                    "LightLevel": 0,
                    "DisplayName": "White Shulker Box"
                },
                "minecraft:orange_shulker_box": {
                    "Color": "#FFD05000",
                    "LightLevel": 0,
                    "DisplayName": "Orange Shulker Box"
                },
                "minecraft:magenta_shulker_box": {
                    "Color": "#FF99228F",
                    "LightLevel": 0,
                    "DisplayName": "Magenta Shulker Box"
                },
                "minecraft:light_blue_shulker_box": {
                    "Color": "#FF1689B8",
                    "LightLevel": 0,
                    "DisplayName": "Light Blue Shulker Box"
                },
                "minecraft:yellow_shulker_box": {
                    "Color": "#FFD29700",
                    "LightLevel": 0,
                    "DisplayName": "Yellow Shulker Box"
                },
                "minecraft:lime_shulker_box": {
                    "Color": "#FF499300",
                    "LightLevel": 0,
                    "DisplayName": "Lime Shulker Box"
                },
                "minecraft:pink_shulker_box": {
                    "Color": "#FFC75B7E",
                    "LightLevel": 0,
                    "DisplayName": "Pink Shulker Box"
                },
                "minecraft:gray_shulker_box": {
                    "Color": "#FF2C2F33",
                    "LightLevel": 0,
                    "DisplayName": "Gray Shulker Box"
                },
                "minecraft:light_gray_shulker_box": {
                    "Color": "#FF65655C",
                    "LightLevel": 0,
                    "DisplayName": "Light Gray Shulker Box"
                },
                "minecraft:cyan_shulker_box": {
                    "Color": "#FF016775",
                    "LightLevel": 0,
                    "DisplayName": "Cyan Shulker Box"
                },
                "minecraft:purple_shulker_box": {
                    "Color": "#FF754A75",
                    "LightLevel": 0,
                    "DisplayName": "Purple Shulker Box"
                },
                "minecraft:blue_shulker_box": {
                    "Color": "#FF202281",
                    "LightLevel": 0,
                    "DisplayName": "Blue Shulker Box"
                },
                "minecraft:brown_shulker_box": {
                    "Color": "#FF5C3315",
                    "LightLevel": 0,
                    "DisplayName": "Brown Shulker Box"
                },
                "minecraft:green_shulker_box": {
                    "Color": "#FF3D530E",
                    "LightLevel": 0,
                    "DisplayName": "Green Shulker Box"
                },
                "minecraft:red_shulker_box": {
                    "Color": "#FF811312",
                    "LightLevel": 0,
                    "DisplayName": "Red Shulker Box"
                },
                "minecraft:black_shulker_box": {
                    "Color": "#FF141418",
                    "LightLevel": 0,
                    "DisplayName": "Black Shulker Box"
                },
                "minecraft:white_glazed_terracotta": {
                    "Color": "#FFC7C7C7",
                    "LightLevel": 0,
                    "DisplayName": "White Glazed Terracotta "
                },
                "minecraft:orange_glazed_terracotta": {
                    "Color": "#FFC74800",
                    "LightLevel": 0,
                    "DisplayName": "Orange Glazed Terracotta "
                },
                "minecraft:magenta_glazed_terracotta": {
                    "Color": "#FF951C8B",
                    "LightLevel": 0,
                    "DisplayName": "Magenta Glazed Terracotta "
                },
                "minecraft:light_blue_glazed_terracotta": {
                    "Color": "#FF0D72B0",
                    "LightLevel": 0,
                    "DisplayName": "Light Blue Glazed Terracotta "
                },
                "minecraft:yellow_glazed_terracotta": {
                    "Color": "#FFCD8B00",
                    "LightLevel": 0,
                    "DisplayName": "Yellow Glazed Terracotta "
                },
                "minecraft:lime_glazed_terracotta": {
                    "Color": "#FF438E00",
                    "LightLevel": 0,
                    "DisplayName": "Lime Glazed Terracotta "
                },
                "minecraft:pink_glazed_terracotta": {
                    "Color": "#FFBA4973",
                    "LightLevel": 0,
                    "DisplayName": "Pink Glazed Terracotta "
                },
                "minecraft:gray_glazed_terracotta": {
                    "Color": "#FF323232",
                    "LightLevel": 0,
                    "DisplayName": "Gray Glazed Terracotta "
                },
                "minecraft:light_gray_glazed_terracotta": {
                    "Color": "#FF646464",
                    "LightLevel": 0,
                    "DisplayName": "Light Gray Glazed Terracotta "
                },
                "minecraft:cyan_glazed_terracotta": {
                    "Color": "#FF026475",
                    "LightLevel": 0,
                    "DisplayName": "Cyan Glazed Terracotta "
                },
                "minecraft:purple_glazed_terracotta": {
                    "Color": "#FF56128E",
                    "LightLevel": 0,
                    "DisplayName": "Purple Glazed Terracotta "
                },
                "minecraft:blue_glazed_terracotta": {
                    "Color": "#FF212383",
                    "LightLevel": 0,
                    "DisplayName": "Blue Glazed Terracotta "
                },
                "minecraft:brown_glazed_terracotta": {
                    "Color": "#FF522E12",
                    "LightLevel": 0,
                    "DisplayName": "Brown Glazed Terracotta "
                },
                "minecraft:green_glazed_terracotta": {
                    "Color": "#FF394B14",
                    "LightLevel": 0,
                    "DisplayName": "Green Glazed Terracotta "
                },
                "minecraft:red_glazed_terracotta": {
                    "Color": "#FF801313",
                    "LightLevel": 0,
                    "DisplayName": "Red Glazed Terracotta "
                },
                "minecraft:black_glazed_terracotta": {
                    "Color": "#FF0D0D0D",
                    "LightLevel": 0,
                    "DisplayName": "Black Glazed Terracotta "
                },
                "minecraft:tube_coral": {
                    "Color": "#FF2C51C4",
                    "LightLevel": 0,
                    "DisplayName": "Tube Coral"
                },
                "minecraft:brain_coral": {
                    "Color": "#FFAD4280",
                    "LightLevel": 0,
                    "DisplayName": "Brain Coral"
                },
                "minecraft:bubble_coral": {
                    "Color": "#FF940C90",
                    "LightLevel": 0,
                    "DisplayName": "Bubble Coral"
                },
                "minecraft:fire_coral": {
                    "Color": "#FF9B171E",
                    "LightLevel": 0,
                    "DisplayName": "Fire Coral"
                },
                "minecraft:horn_coral": {
                    "Color": "#FFAD991B",
                    "LightLevel": 0,
                    "DisplayName": "Horn Coral"
                },
                "minecraft:dead_tube_coral": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Tube Coral"
                },
                "minecraft:dead_brain_coral": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Brain Coral"
                },
                "minecraft:dead_bubble_coral": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Bubble Coral"
                },
                "minecraft:dead_fire_coral": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Fire Coral"
                },
                "minecraft:dead_horn_coral": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Horn Coral"
                },
                "minecraft:tube_coral_fan": {
                    "Color": "#FF2C51C4",
                    "LightLevel": 0,
                    "DisplayName": "Tube Coral Fan"
                },
                "minecraft:brain_coral_fan": {
                    "Color": "#FFAD4280",
                    "LightLevel": 0,
                    "DisplayName": "Brain Coral Fan"
                },
                "minecraft:bubble_coral_fan": {
                    "Color": "#FF940C90",
                    "LightLevel": 0,
                    "DisplayName": "Bubble Coral Fan"
                },
                "minecraft:fire_coral_fan": {
                    "Color": "#FF9B171E",
                    "LightLevel": 0,
                    "DisplayName": "Fire Coral Fan"
                },
                "minecraft:horn_coral_fan": {
                    "Color": "#FFAD991B",
                    "LightLevel": 0,
                    "DisplayName": "Horn Coral Fan"
                },
                "minecraft:dead_tube_coral_fan": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Tube Coral Fan"
                },
                "minecraft:dead_brain_coral_fan": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Brain Coral Fan"
                },
                "minecraft:dead_bubble_coral_fan": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Bubble Coral Fan"
                },
                "minecraft:dead_fire_coral_fan": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Fire Coral Fan"
                },
                "minecraft:dead_horn_coral_fan": {
                    "Color": "#FF6B645F",
                    "LightLevel": 0,
                    "DisplayName": "Dead Horn Coral Fan"
                },
                "minecraft:oak_sign": {
                    "Color": "#FF937840",
                    "LightLevel": 0,
                    "DisplayName": "Oak Sign"
                },
                "minecraft:spruce_sign": {
                    "Color": "#FF654523",
                    "LightLevel": 0,
                    "DisplayName": "Spruce Sign"
                },
                "minecraft:birch_sign": {
                    "Color": "#FFB09A5E",
                    "LightLevel": 0,
                    "DisplayName": "Birch Sign"
                },
                "minecraft:jungle_sign": {
                    "Color": "#FF956440",
                    "LightLevel": 0,
                    "DisplayName": "Jungle Sign"
                },
                "minecraft:acacia_sign": {
                    "Color": "#FFA14F22",
                    "LightLevel": 0,
                    "DisplayName": "Acacia Sign"
                },
                "minecraft:dark_oak_sign": {
                    "Color": "#FF3E240C",
                    "LightLevel": 0,
                    "DisplayName": "Dark Oak Sign"
                },
                "minecraft:crimson_sign": {
                    "Color": "#FF5B243B",
                    "LightLevel": 0,
                    "DisplayName": "Crimson Sign"
                },
                "minecraft:warped_sign": {
                    "Color": "#FF1B5B56",
                    "LightLevel": 0,
                    "DisplayName": "Warped Sign"
                },
                "minecraft:white_bed": {
                    "Color": "#FFE3E3E3",
                    "LightLevel": 0,
                    "DisplayName": "White Bed"
                },
                "minecraft:orange_bed": {
                    "Color": "#FFE35300",
                    "LightLevel": 0,
                    "DisplayName": "Orange Bed"
                },
                "minecraft:magenta_bed": {
                    "Color": "#FFBC26AF",
                    "LightLevel": 0,
                    "DisplayName": "Magenta Bed"
                },
                "minecraft:light_blue_bed": {
                    "Color": "#FF1288D0",
                    "LightLevel": 0,
                    "DisplayName": "Light Blue Bed"
                },
                "minecraft:yellow_bed": {
                    "Color": "#FFE89E00",
                    "LightLevel": 0,
                    "DisplayName": "Yellow Bed"
                },
                "minecraft:lime_bed": {
                    "Color": "#FF58B600",
                    "LightLevel": 0,
                    "DisplayName": "Lime Bed"
                },
                "minecraft:pink_bed": {
                    "Color": "#FFD95687",
                    "LightLevel": 0,
                    "DisplayName": "Pink Bed"
                },
                "minecraft:gray_bed": {
                    "Color": "#FF9B9B9B",
                    "LightLevel": 0,
                    "DisplayName": "Gray Bed"
                },
                "minecraft:light_gray_bed": {
                    "Color": "#FF7C7C76",
                    "LightLevel": 0,
                    "DisplayName": "Light Gray Bed"
                },
                "minecraft:cyan_bed": {
                    "Color": "#FF048EA5",
                    "LightLevel": 0,
                    "DisplayName": "Cyan Bed"
                },
                "minecraft:purple_bed": {
                    "Color": "#FF701AB6",
                    "LightLevel": 0,
                    "DisplayName": "Purple Bed"
                },
                "minecraft:blue_bed": {
                    "Color": "#FF2F32AF",
                    "LightLevel": 0,
                    "DisplayName": "Blue Bed"
                },
                "minecraft:brown_bed": {
                    "Color": "#FF77451E",
                    "LightLevel": 0,
                    "DisplayName": "Brown Bed"
                },
                "minecraft:green_bed": {
                    "Color": "#FF597323",
                    "LightLevel": 0,
                    "DisplayName": "Green Bed"
                },
                "minecraft:red_bed": {
                    "Color": "#FFAD1D1D",
                    "LightLevel": 0,
                    "DisplayName": "Red Bed"
                },
                "minecraft:black_bed": {
                    "Color": "#FF424242",
                    "LightLevel": 0,
                    "DisplayName": "Black Bed"
                },
                "minecraft:scaffolding": {
                    "Color": "#FFA9834A",
                    "LightLevel": 0,
                    "DisplayName": "Scaffolding"
                },
                "minecraft:flower_pot": {
                    "Color": "#FF743F31",
                    "LightLevel": 0,
                    "DisplayName": "Flower Pot"
                },
                "minecraft:skeleton_head": {
                    "Color": "#FFA1A1A1",
                    "LightLevel": 0,
                    "DisplayName": "Skeleton Head"
                },
                "minecraft:wither_skeleton_head": {
                    "Color": "#FFA1A1A1",
                    "LightLevel": 0,
                    "DisplayName": "Wither Skeleton Head"
                },
                "minecraft:player_head": {
                    "Color": "#FFA1A1A1",
                    "LightLevel": 0,
                    "DisplayName": "Player Head"
                },
                "minecraft:zombie_head": {
                    "Color": "#FFA1A1A1",
                    "LightLevel": 0,
                    "DisplayName": "Zombie Head"
                },
                "minecraft:creeper_head": {
                    "Color": "#FFA1A1A1",
                    "LightLevel": 0,
                    "DisplayName": "Creeper Head"
                },
                "minecraft:dragon_head": {
                    "Color": "#FFA1A1A1",
                    "LightLevel": 0,
                    "DisplayName": "Dragon Head"
                },
                "minecraft:white_banner": {
                    "Color": "#FFE3E3E3",
                    "LightLevel": 0,
                    "DisplayName": "White Banner"
                },
                "minecraft:orange_banner": {
                    "Color": "#FFE35300",
                    "LightLevel": 0,
                    "DisplayName": "Orange Banner"
                },
                "minecraft:magenta_banner": {
                    "Color": "#FFBC26AF",
                    "LightLevel": 0,
                    "DisplayName": "Magenta Banner"
                },
                "minecraft:light_blue_banner": {
                    "Color": "#FF1288D0",
                    "LightLevel": 0,
                    "DisplayName": "Light Blue Banner"
                },
                "minecraft:yellow_banner": {
                    "Color": "#FFE89E00",
                    "LightLevel": 0,
                    "DisplayName": "Yellow Banner"
                },
                "minecraft:lime_banner": {
                    "Color": "#FF58B600",
                    "LightLevel": 0,
                    "DisplayName": "Lime Banner"
                },
                "minecraft:pink_banner": {
                    "Color": "#FFD95687",
                    "LightLevel": 0,
                    "DisplayName": "Pink Banner"
                },
                "minecraft:gray_banner": {
                    "Color": "#FF9B9B9B",
                    "LightLevel": 0,
                    "DisplayName": "Gray Banner"
                },
                "minecraft:light_gray_banner": {
                    "Color": "#FF7C7C76",
                    "LightLevel": 0,
                    "DisplayName": "Light Gray Banner"
                },
                "minecraft:cyan_banner": {
                    "Color": "#FF048EA5",
                    "LightLevel": 0,
                    "DisplayName": "Cyan Banner"
                },
                "minecraft:purple_banner": {
                    "Color": "#FF701AB6",
                    "LightLevel": 0,
                    "DisplayName": "Purple Banner"
                },
                "minecraft:blue_banner": {
                    "Color": "#FF2F32AF",
                    "LightLevel": 0,
                    "DisplayName": "Blue Banner"
                },
                "minecraft:brown_banner": {
                    "Color": "#FF77451E",
                    "LightLevel": 0,
                    "DisplayName": "Brown Banner"
                },
                "minecraft:green_banner": {
                    "Color": "#FF597323",
                    "LightLevel": 0,
                    "DisplayName": "Green Banner"
                },
                "minecraft:red_banner": {
                    "Color": "#FFAD1D1D",
                    "LightLevel": 0,
                    "DisplayName": "Red Banner"
                },
                "minecraft:black_banner": {
                    "Color": "#FF424242",
                    "LightLevel": 0,
                    "DisplayName": "Black Banner"
                },
                "minecraft:loom": {
                    "Color": "#FF907962",
                    "LightLevel": 0,
                    "DisplayName": "Loom"
                },
                "minecraft:composter": {
                    "Color": "#FF663B16",
                    "LightLevel": 0,
                    "DisplayName": "Composter"
                },
                "minecraft:barrel": {
                    "Color": "#FF704E25",
                    "LightLevel": 0,
                    "DisplayName": "Barrel"
                },
                "minecraft:smoker": {
                    "Color": "#FF494746",
                    "LightLevel": 0,
                    "DisplayName": "Smoker"
                },
                "minecraft:blast_furnace": {
                    "Color": "#FF424142",
                    "LightLevel": 0,
                    "DisplayName": "Blast Furnace"
                },
                "minecraft:cartography_table": {
                    "Color": "#FF695D55",
                    "LightLevel": 0,
                    "DisplayName": "Cartography Table"
                },
                "minecraft:fletching_table": {
                    "Color": "#FFA39267",
                    "LightLevel": 0,
                    "DisplayName": "Fletching Table"
                },
                "minecraft:grindstone": {
                    "Color": "#FF717171",
                    "LightLevel": 0,
                    "DisplayName": "Grindstone"
                },
                "minecraft:smithing_table": {
                    "Color": "#FF2E2F3C",
                    "LightLevel": 0,
                    "DisplayName": "Smithing Table"
                },
                "minecraft:stonecutter": {
                    "Color": "#FF64605C",
                    "LightLevel": 0,
                    "DisplayName": "Stonecutter"
                },
                "minecraft:bell": {
                    "Color": "#FFBB932B",
                    "LightLevel": 0,
                    "DisplayName": "Bell"
                },
                "minecraft:lantern": {
                    "Color": "#FFE1A153",
                    "LightLevel": 15,
                    "DisplayName": "Lantern"
                },
                "minecraft:soul_lantern": {
                    "Color": "#FF97C3C5",
                    "LightLevel": 10,
                    "DisplayName": "Soul Lantern"
                },
                "minecraft:campfire": {
                    "Color": "#FFD3A556",
                    "LightLevel": 15,
                    "DisplayName": "Campfire"
                },
                "minecraft:soul_campfire": {
                    "Color": "#FF23BEC4",
                    "LightLevel": 10,
                    "DisplayName": "Soul Campfire"
                },
                "minecraft:shroomlight": {
                    "Color": "#FFCF793B",
                    "LightLevel": 15,
                    "DisplayName": "Shroomlight"
                },
                "minecraft:bee_nest": {
                    "Color": "#FFAF8A2E",
                    "LightLevel": 0,
                    "DisplayName": "Bee Nest"
                },
                "minecraft:beehive": {
                    "Color": "#FF96743C",
                    "LightLevel": 0,
                    "DisplayName": "Beehive"
                },
                "minecraft:honeycomb_block": {
                    "Color": "#FFC47913",
                    "LightLevel": 0,
                    "DisplayName": "Honeycomb Block"
                },
                "minecraft:lodestone": {
                    "Color": "#FF636466",
                    "LightLevel": 0,
                    "DisplayName": "Lodestone"
                },
                "minecraft:respawn_anchor": {
                    "Color": "#FF5302B8",
                    "LightLevel": 0,
                    "DisplayName": "Respawn Anchor"
                },
                "minecraft:beacon": {
                    "Color": "#FF85D4BB",
                    "LightLevel": 15,
                    "DisplayName": "Beacon"
                },
                "minecraft:water": {
                    "Color": "#FF22417F",
                    "LightLevel": 0,
                    "DisplayName": "Water"
                },
                "minecraft:bubble_column": {
                    "Color": "#FF22417F",
                    "LightLevel": 0,
                    "DisplayName": "Bubble Column"
                },
                "minecraft:lava": {
                    "Color": "#FFCC4600",
                    "LightLevel": 15,
                    "DisplayName": "Lava"
                }
            }
        }
        
        """;

        return JsonSerializer.Deserialize<ViewportDefinition>(input)!;
    }
}
