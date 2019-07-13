﻿using UnityEngine;

public class CustomCharacterManager : MonoBehaviour
{
    private int capeId;
    private int[] capeOption;
    public GameObject character;
    private int costumeId = 1;
    private HeroCostume[] costumeOption;
    private string currentSlot = "Set 1";
    private int divisionId;
    private DIVISION[] divisionOption;
    private int eyeId;
    private int[] eyeOption;
    private int faceId;
    private int[] faceOption;
    private int glassId;
    private int[] glassOption;
    public GameObject hairB;
    public GameObject hairG;
    private int hairId;
    private int[] hairOption;
    public GameObject hairR;
    public GameObject labelACL;
    public GameObject labelBLA;
    public GameObject labelCape;
    public GameObject labelCostume;
    public GameObject labelDivision;
    public GameObject labelEye;
    public GameObject labelFace;
    public GameObject labelGAS;
    public GameObject labelGlass;
    public GameObject labelHair;
    public GameObject labelPOINT;
    public GameObject labelPreset;
    public GameObject labelSex;
    public GameObject labelSKILL;
    public GameObject labelSkin;
    public GameObject labelSPD;
    private int presetId;
    private HERO_SETUP setup;
    private int sexId;
    private SEX[] sexOption;
    private int skillId;
    private string[] skillOption;
    private int skinId;
    private int[] skinOption;

    private int calTotalPoints()
    {
        if (setup.myCostume != null)
        {
            var num = 0;
            num += setup.myCostume.stat.SPD;
            num += setup.myCostume.stat.GAS;
            num += setup.myCostume.stat.BLA;
            return num + setup.myCostume.stat.ACL;
        }
        return 400;
    }

    private void copyBodyCostume(HeroCostume from, HeroCostume to)
    {
        to.arm_l_mesh = from.arm_l_mesh;
        to.arm_r_mesh = from.arm_r_mesh;
        to.body_mesh = from.body_mesh;
        to.body_texture = from.body_texture;
        to.uniform_type = from.uniform_type;
        to.part_chest_1_object_mesh = from.part_chest_1_object_mesh;
        to.part_chest_1_object_texture = from.part_chest_1_object_texture;
        to.part_chest_object_mesh = from.part_chest_object_mesh;
        to.part_chest_object_texture = from.part_chest_object_texture;
        to.part_chest_skinned_cloth_mesh = from.part_chest_skinned_cloth_mesh;
        to.part_chest_skinned_cloth_texture = from.part_chest_skinned_cloth_texture;
        to.division = from.division;
        to.id = from.id;
        to.costumeId = from.costumeId;
    }

    private void copyCostume(HeroCostume from, HeroCostume to, bool init = false)
    {
        copyBodyCostume(from, to);
        to.sex = from.sex;
        to.hair_mesh = from.hair_mesh;
        to.hair_1_mesh = from.hair_1_mesh;
        to.hair_color = new Color(from.hair_color.r, from.hair_color.g, from.hair_color.b);
        to.hairInfo = from.hairInfo;
        to.cape = from.cape;
        to.cape_mesh = from.cape_mesh;
        to.cape_texture = from.cape_texture;
        to.brand1_mesh = from.brand1_mesh;
        to.brand2_mesh = from.brand2_mesh;
        to.brand3_mesh = from.brand3_mesh;
        to.brand4_mesh = from.brand4_mesh;
        to.brand_texture = from.brand_texture;
        to._3dmg_texture = from._3dmg_texture;
        to.face_texture = from.face_texture;
        to.eye_mesh = from.eye_mesh;
        to.glass_mesh = from.glass_mesh;
        to.beard_mesh = from.beard_mesh;
        to.eye_texture_id = from.eye_texture_id;
        to.beard_texture_id = from.beard_texture_id;
        to.glass_texture_id = from.glass_texture_id;
        to.skin_color = from.skin_color;
        to.skin_texture = from.skin_texture;
        to.beard_texture_id = from.beard_texture_id;
        to.hand_l_mesh = from.hand_l_mesh;
        to.hand_r_mesh = from.hand_r_mesh;
        to.mesh_3dmg = from.mesh_3dmg;
        to.mesh_3dmg_gas_l = from.mesh_3dmg_gas_l;
        to.mesh_3dmg_gas_r = from.mesh_3dmg_gas_r;
        to.mesh_3dmg_belt = from.mesh_3dmg_belt;
        to.weapon_l_mesh = from.weapon_l_mesh;
        to.weapon_r_mesh = from.weapon_r_mesh;
        if (init)
        {
            to.stat = new HeroStat();
            to.stat.ACL = 100;
            to.stat.SPD = 100;
            to.stat.GAS = 100;
            to.stat.BLA = 100;
            to.stat.skillId = "mikasa";
        }
        else
        {
            to.stat = new HeroStat();
            to.stat.ACL = from.stat.ACL;
            to.stat.SPD = from.stat.SPD;
            to.stat.GAS = from.stat.GAS;
            to.stat.BLA = from.stat.BLA;
            to.stat.skillId = from.stat.skillId;
        }
    }

    private void CostumeDataToMyID()
    {
        var index = 0;
        for (index = 0; index < sexOption.Length; index++)
        {
            if (sexOption[index] == setup.myCostume.sex)
            {
                sexId = index;
                break;
            }
        }
        index = 0;
        while (index < eyeOption.Length)
        {
            if (eyeOption[index] == setup.myCostume.eye_texture_id)
            {
                eyeId = index;
                break;
            }
            index++;
        }
        faceId = -1;
        for (index = 0; index < faceOption.Length; index++)
        {
            if (faceOption[index] == setup.myCostume.beard_texture_id)
            {
                faceId = index;
                break;
            }
        }
        glassId = -1;
        for (index = 0; index < glassOption.Length; index++)
        {
            if (glassOption[index] == setup.myCostume.glass_texture_id)
            {
                glassId = index;
                break;
            }
        }
        for (index = 0; index < hairOption.Length; index++)
        {
            if (hairOption[index] == setup.myCostume.hairInfo.id)
            {
                hairId = index;
                break;
            }
        }
        for (index = 0; index < skinOption.Length; index++)
        {
            if (skinOption[index] == setup.myCostume.skin_color)
            {
                skinId = index;
                break;
            }
        }
        if (setup.myCostume.cape)
        {
            capeId = 1;
        }
        else
        {
            capeId = 0;
        }
        index = 0;
        while (index < divisionOption.Length)
        {
            if (divisionOption[index] == setup.myCostume.division)
            {
                divisionId = index;
                break;
            }
            index++;
        }
        costumeId = setup.myCostume.costumeId;
        var r = setup.myCostume.hair_color.r;
        var g = setup.myCostume.hair_color.g;
        var b = setup.myCostume.hair_color.b;
        hairR.GetComponent<UISlider>().sliderValue = r;
        hairG.GetComponent<UISlider>().sliderValue = g;
        hairB.GetComponent<UISlider>().sliderValue = b;
        for (index = 0; index < skillOption.Length; index++)
        {
            if (skillOption[index] == setup.myCostume.stat.skillId)
            {
                skillId = index;
                break;
            }
        }
    }

    private void freshLabel()
    {
        labelSex.GetComponent<UILabel>().text = sexOption[sexId].ToString();
        labelEye.GetComponent<UILabel>().text = "eye_" + eyeId;
        labelFace.GetComponent<UILabel>().text = "face_" + faceId;
        labelGlass.GetComponent<UILabel>().text = "glass_" + glassId;
        labelHair.GetComponent<UILabel>().text = "hair_" + hairId;
        labelSkin.GetComponent<UILabel>().text = "skin_" + skinId;
        labelCostume.GetComponent<UILabel>().text = "costume_" + costumeId;
        labelCape.GetComponent<UILabel>().text = "cape_" + capeId;
        labelDivision.GetComponent<UILabel>().text = divisionOption[divisionId].ToString();
        labelPOINT.GetComponent<UILabel>().text = "Points: " + (400 - calTotalPoints());
        labelSPD.GetComponent<UILabel>().text = "SPD " + setup.myCostume.stat.SPD;
        labelGAS.GetComponent<UILabel>().text = "GAS " + setup.myCostume.stat.GAS;
        labelBLA.GetComponent<UILabel>().text = "BLA " + setup.myCostume.stat.BLA;
        labelACL.GetComponent<UILabel>().text = "ACL " + setup.myCostume.stat.ACL;
        labelSKILL.GetComponent<UILabel>().text = "SKILL " + setup.myCostume.stat.skillId;
    }

    public void LoadData()
    {
        var from = CostumeConeveter.LocalDataToHeroCostume(currentSlot);
        if (from != null)
        {
            copyCostume(from, setup.myCostume);
            setup.deleteCharacterComponent2();
            setup.setCharacterComponent();
        }
        CostumeDataToMyID();
        freshLabel();
    }

    public void nextOption(CreatePart part)
    {
        if (part == CreatePart.Preset)
        {
            presetId = toNext(presetId, HeroCostume.costume.Length);
            copyCostume(HeroCostume.costume[presetId], setup.myCostume, true);
            CostumeDataToMyID();
            setup.deleteCharacterComponent2();
            setup.setCharacterComponent();
            labelPreset.GetComponent<UILabel>().text = HeroCostume.costume[presetId].name;
            freshLabel();
        }
        else
        {
            toOption2(part, true);
        }
    }

    public void nextStatOption(CreateStat type)
    {
        if (type == CreateStat.Skill)
        {
            skillId = toNext(skillId, skillOption.Length);
            setup.myCostume.stat.skillId = skillOption[skillId];
            character.GetComponent<CharacterCreateAnimationControl>().playAttack(setup.myCostume.stat.skillId);
            freshLabel();
        }
        else if (calTotalPoints() < 400)
        {
            setStatPoint(type, 1);
        }
    }

    public void OnHairBChange(float value)
    {
        if (setup != null && setup.myCostume != null && setup.part_hair != null)
        {
            setup.myCostume.hair_color = new Color(setup.part_hair.renderer.material.color.r, setup.part_hair.renderer.material.color.g, value);
            setHairColor();
        }
    }

    public void OnHairGChange(float value)
    {
        if (setup.myCostume != null && setup.part_hair != null)
        {
            setup.myCostume.hair_color = new Color(setup.part_hair.renderer.material.color.r, value, setup.part_hair.renderer.material.color.b);
            setHairColor();
        }
    }

    public void OnHairRChange(float value)
    {
        if (setup.myCostume != null && setup.part_hair != null)
        {
            setup.myCostume.hair_color = new Color(value, setup.part_hair.renderer.material.color.g, setup.part_hair.renderer.material.color.b);
            setHairColor();
        }
    }

    public void OnSoltChange(string id)
    {
        currentSlot = id;
    }

    public void prevOption(CreatePart part)
    {
        if (part == CreatePart.Preset)
        {
            presetId = toPrev(presetId, HeroCostume.costume.Length);
            copyCostume(HeroCostume.costume[presetId], setup.myCostume, true);
            CostumeDataToMyID();
            setup.deleteCharacterComponent2();
            setup.setCharacterComponent();
            labelPreset.GetComponent<UILabel>().text = HeroCostume.costume[presetId].name;
            freshLabel();
        }
        else
        {
            toOption2(part, false);
        }
    }

    public void prevStatOption(CreateStat type)
    {
        if (type == CreateStat.Skill)
        {
            skillId = toPrev(skillId, skillOption.Length);
            setup.myCostume.stat.skillId = skillOption[skillId];
            character.GetComponent<CharacterCreateAnimationControl>().playAttack(setup.myCostume.stat.skillId);
            freshLabel();
        }
        else
        {
            setStatPoint(type, -1);
        }
    }

    public void SaveData()
    {
        CostumeConeveter.HeroCostumeToLocalData(setup.myCostume, currentSlot);
    }

    private void setHairColor()
    {
        if (setup.part_hair != null)
        {
            setup.part_hair.renderer.material.color = setup.myCostume.hair_color;
        }
        if (setup.part_hair_1 != null)
        {
            setup.part_hair_1.renderer.material.color = setup.myCostume.hair_color;
        }
    }

    private void setStatPoint(CreateStat type, int pt)
    {
        switch (type)
        {
            case CreateStat.SPD:
                setup.myCostume.stat.SPD += pt;
                break;

            case CreateStat.GAS:
                setup.myCostume.stat.GAS += pt;
                break;

            case CreateStat.BLA:
                setup.myCostume.stat.BLA += pt;
                break;

            case CreateStat.ACL:
                setup.myCostume.stat.ACL += pt;
                break;
        }
        setup.myCostume.stat.SPD = Mathf.Clamp(setup.myCostume.stat.SPD, 75, 125);
        setup.myCostume.stat.GAS = Mathf.Clamp(setup.myCostume.stat.GAS, 75, 125);
        setup.myCostume.stat.BLA = Mathf.Clamp(setup.myCostume.stat.BLA, 75, 125);
        setup.myCostume.stat.ACL = Mathf.Clamp(setup.myCostume.stat.ACL, 75, 125);
        freshLabel();
    }

    private void Start()
    {
        int num;
        QualitySettings.SetQualityLevel(5, true);
        costumeOption = HeroCostume.costumeOption;
        setup = character.GetComponent<HERO_SETUP>();
        setup.init();
        setup.myCostume = new HeroCostume();
        copyCostume(HeroCostume.costume[2], setup.myCostume);
        setup.myCostume.setMesh2();
        setup.setCharacterComponent();
        var sexArray1 = new SEX[2];
        sexArray1[1] = SEX.FEMALE;
        sexOption = sexArray1;
        eyeOption = new int[28];
        for (num = 0; num < 28; num++)
        {
            eyeOption[num] = num;
        }
        faceOption = new int[14];
        for (num = 0; num < 14; num++)
        {
            faceOption[num] = num + 32;
        }
        glassOption = new int[10];
        for (num = 0; num < 10; num++)
        {
            glassOption[num] = num + 48;
        }
        hairOption = new int[11];
        for (num = 0; num < 11; num++)
        {
            hairOption[num] = num;
        }
        skinOption = new int[3];
        for (num = 0; num < 3; num++)
        {
            skinOption[num] = num + 1;
        }
        capeOption = new int[2];
        for (num = 0; num < 2; num++)
        {
            capeOption[num] = num;
        }
        var divisionArray1 = new DIVISION[4];
        divisionArray1[1] = DIVISION.TheGarrison;
        divisionArray1[2] = DIVISION.TheMilitaryPolice;
        divisionArray1[3] = DIVISION.TheSurveryCorps;
        divisionOption = divisionArray1;
        skillOption = new[] { "mikasa", "levi", "sasha", "jean", "marco", "armin", "petra" };
        CostumeDataToMyID();
        freshLabel();
    }

    private int toNext(int id, int Count, int start = 0)
    {
        id++;
        if (id >= Count)
        {
            id = start;
        }
        id = Mathf.Clamp(id, start, start + Count - 1);
        return id;
    }

    public void toOption(CreatePart part, bool next)
    {
        switch (part)
        {
            case CreatePart.Sex:
                sexId = !next ? toPrev(sexId, sexOption.Length) : toNext(sexId, sexOption.Length);
                if (sexId != 0)
                {
                    costumeId = 0;
                    break;
                }
                costumeId = 11;
                break;

            case CreatePart.Eye:
                eyeId = !next ? toPrev(eyeId, eyeOption.Length) : toNext(eyeId, eyeOption.Length);
                setup.myCostume.eye_texture_id = eyeId;
                setup.setFacialTexture(setup.part_eye, eyeOption[eyeId]);
                goto Label_06AE;

            case CreatePart.Face:
                faceId = !next ? toPrev(faceId, faceOption.Length) : toNext(faceId, faceOption.Length);
                setup.myCostume.beard_texture_id = faceOption[faceId];
                if (setup.part_face == null)
                {
                    setup.createFace();
                }
                setup.setFacialTexture(setup.part_face, faceOption[faceId]);
                goto Label_06AE;

            case CreatePart.Glass:
                glassId = !next ? toPrev(glassId, glassOption.Length) : toNext(glassId, glassOption.Length);
                setup.myCostume.glass_texture_id = glassOption[glassId];
                if (setup.part_glass == null)
                {
                    setup.createGlass();
                }
                setup.setFacialTexture(setup.part_glass, glassOption[glassId]);
                goto Label_06AE;

            case CreatePart.Hair:
                hairId = !next ? toPrev(hairId, hairOption.Length) : toNext(hairId, hairOption.Length);
                if (sexId != 0)
                {
                    setup.myCostume.hair_mesh = CostumeHair.hairsF[hairOption[hairId]].hair;
                    setup.myCostume.hair_1_mesh = CostumeHair.hairsF[hairOption[hairId]].hair_1;
                    setup.myCostume.hairInfo = CostumeHair.hairsF[hairOption[hairId]];
                }
                else
                {
                    setup.myCostume.hair_mesh = CostumeHair.hairsM[hairOption[hairId]].hair;
                    setup.myCostume.hair_1_mesh = CostumeHair.hairsM[hairOption[hairId]].hair_1;
                    setup.myCostume.hairInfo = CostumeHair.hairsM[hairOption[hairId]];
                }
                setup.createHair2();
                setHairColor();
                goto Label_06AE;

            case CreatePart.Skin:
                if (setup.myCostume.uniform_type != UNIFORM_TYPE.CasualAHSS)
                {
                    skinId = !next ? toPrev(skinId, 2) : toNext(skinId, 2);
                }
                else
                {
                    skinId = 2;
                }
                setup.myCostume.skin_color = skinOption[skinId];
                setup.myCostume.setTexture();
                setup.setSkin();
                goto Label_06AE;

            case CreatePart.Costume:
                if (setup.myCostume.uniform_type != UNIFORM_TYPE.CasualAHSS)
                {
                    if (sexId == 0)
                    {
                        costumeId = !next ? toPrev(costumeId, 24, 10) : toNext(costumeId, 24, 10);
                    }
                    else
                    {
                        costumeId = !next ? toPrev(costumeId, 10) : toNext(costumeId, 10);
                    }
                }
                else
                {
                    costumeId = 25;
                }
                copyBodyCostume(costumeOption[costumeId], setup.myCostume);
                setup.myCostume.setMesh2();
                setup.myCostume.setTexture();
                setup.createUpperBody2();
                setup.createLeftArm();
                setup.createRightArm();
                setup.createLowerBody();
                goto Label_06AE;

            case CreatePart.Cape:
                capeId = !next ? toPrev(capeId, capeOption.Length) : toNext(capeId, capeOption.Length);
                setup.myCostume.cape = capeId == 1;
                setup.myCostume.setCape();
                setup.myCostume.setTexture();
                setup.createCape2();
                goto Label_06AE;

            case CreatePart.Division:
                divisionId = !next ? toPrev(divisionId, divisionOption.Length) : toNext(divisionId, divisionOption.Length);
                setup.myCostume.division = divisionOption[divisionId];
                setup.myCostume.setTexture();
                setup.createUpperBody2();
                goto Label_06AE;

            default:
                goto Label_06AE;
        }
        copyCostume(costumeOption[costumeId], setup.myCostume, true);
        setup.myCostume.sex = sexOption[sexId];
        character.GetComponent<CharacterCreateAnimationControl>().toStand();
        CostumeDataToMyID();
        setup.deleteCharacterComponent2();
        setup.setCharacterComponent();
        Label_06AE:
        freshLabel();
    }

    public void toOption2(CreatePart part, bool next)
    {
        switch (part)
        {
            case CreatePart.Sex:
                sexId = !next ? toPrev(sexId, sexOption.Length) : toNext(sexId, sexOption.Length);
                if (sexId == 0)
                {
                    costumeId = 11;
                }
                else
                {
                    costumeId = 0;
                }
                copyCostume(costumeOption[costumeId], setup.myCostume, true);
                setup.myCostume.sex = sexOption[sexId];
                character.GetComponent<CharacterCreateAnimationControl>().toStand();
                CostumeDataToMyID();
                setup.deleteCharacterComponent2();
                setup.setCharacterComponent();
                goto Label_0750;

            case CreatePart.Eye:
                eyeId = !next ? toPrev(eyeId, eyeOption.Length) : toNext(eyeId, eyeOption.Length);
                setup.myCostume.eye_texture_id = eyeId;
                setup.setFacialTexture(setup.part_eye, eyeOption[eyeId]);
                goto Label_0750;

            case CreatePart.Face:
                faceId = !next ? toPrev(faceId, faceOption.Length) : toNext(faceId, faceOption.Length);
                setup.myCostume.beard_texture_id = faceOption[faceId];
                if (setup.part_face == null)
                {
                    setup.createFace();
                }
                setup.setFacialTexture(setup.part_face, faceOption[faceId]);
                goto Label_0750;

            case CreatePart.Glass:
                glassId = !next ? toPrev(glassId, glassOption.Length) : toNext(glassId, glassOption.Length);
                setup.myCostume.glass_texture_id = glassOption[glassId];
                if (setup.part_glass == null)
                {
                    setup.createGlass();
                }
                setup.setFacialTexture(setup.part_glass, glassOption[glassId]);
                goto Label_0750;

            case CreatePart.Hair:
                hairId = !next ? toPrev(hairId, hairOption.Length) : toNext(hairId, hairOption.Length);
                if (sexId == 0)
                {
                    setup.myCostume.hair_mesh = CostumeHair.hairsM[hairOption[hairId]].hair;
                    setup.myCostume.hair_1_mesh = CostumeHair.hairsM[hairOption[hairId]].hair_1;
                    setup.myCostume.hairInfo = CostumeHair.hairsM[hairOption[hairId]];
                    break;
                }
                setup.myCostume.hair_mesh = CostumeHair.hairsF[hairOption[hairId]].hair;
                setup.myCostume.hair_1_mesh = CostumeHair.hairsF[hairOption[hairId]].hair_1;
                setup.myCostume.hairInfo = CostumeHair.hairsF[hairOption[hairId]];
                break;

            case CreatePart.Skin:
                if (setup.myCostume.uniform_type == UNIFORM_TYPE.CasualAHSS)
                {
                    skinId = 2;
                }
                else
                {
                    skinId = !next ? toPrev(skinId, 2) : toNext(skinId, 2);
                }
                setup.myCostume.skin_color = skinOption[skinId];
                setup.myCostume.setTexture();
                setup.setSkin();
                goto Label_0750;

            case CreatePart.Costume:
                if (setup.myCostume.uniform_type == UNIFORM_TYPE.CasualAHSS)
                {
                    if (setup.myCostume.sex == SEX.FEMALE)
                    {
                        costumeId = 26;
                    }
                    else if (setup.myCostume.sex == SEX.MALE)
                    {
                        costumeId = 25;
                    }
                }
                else if (sexId != 0)
                {
                    costumeId = !next ? toPrev(costumeId, 10) : toNext(costumeId, 10);
                }
                else
                {
                    costumeId = !next ? toPrev(costumeId, 24, 10) : toNext(costumeId, 24, 10);
                }
                copyBodyCostume(costumeOption[costumeId], setup.myCostume);
                setup.myCostume.setMesh2();
                setup.myCostume.setTexture();
                setup.createUpperBody2();
                setup.createLeftArm();
                setup.createRightArm();
                setup.createLowerBody();
                goto Label_0750;

            case CreatePart.Cape:
                capeId = !next ? toPrev(capeId, capeOption.Length) : toNext(capeId, capeOption.Length);
                setup.myCostume.cape = capeId == 1;
                setup.myCostume.setCape();
                setup.myCostume.setTexture();
                setup.createCape2();
                goto Label_0750;

            case CreatePart.Division:
                divisionId = !next ? toPrev(divisionId, divisionOption.Length) : toNext(divisionId, divisionOption.Length);
                setup.myCostume.division = divisionOption[divisionId];
                setup.myCostume.setTexture();
                setup.createUpperBody2();
                goto Label_0750;

            default:
                goto Label_0750;
        }
        setup.createHair2();
        setHairColor();
        Label_0750:
        freshLabel();
    }

    private int toPrev(int id, int Count, int start = 0)
    {
        id--;
        if (id < start)
        {
            id = Count - 1;
        }
        id = Mathf.Clamp(id, start, start + Count - 1);
        return id;
    }
}