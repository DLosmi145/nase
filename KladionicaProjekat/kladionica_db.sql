-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema Kladionica
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Kladionica
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Kladionica` DEFAULT CHARACTER SET utf8 ;
USE `Kladionica` ;

-- -----------------------------------------------------
-- Table `Kladionica`.`Zaposleni`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`Zaposleni` (
  `IDZaposleni` INT NOT NULL AUTO_INCREMENT,
  `Ime` CHAR(45) NULL,
  `Prezime` CHAR(45) NULL,
  `BrojTelefona` VARCHAR(12) NULL,
  `Adresa` CHAR(25) NULL,
  `Sifra` CHAR(15) NULL,
  `NivoPristupa` CHAR(25) NULL,
  PRIMARY KEY (`IDZaposleni`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Kladionica`.`SifraUplatnogMjesta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`SifraUplatnogMjesta` (
  `Sifra` VARCHAR(9) NOT NULL,
  `Naziv` CHAR(25) NULL,
  `Adresa` CHAR(25) NULL,
  PRIMARY KEY (`Sifra`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Kladionica`.`Igrac`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`Igrac` (
  `IDIgrac` INT(10) NOT NULL AUTO_INCREMENT,
  `Ime` CHAR(20) NULL,
  `Prezime` CHAR(20) NULL,
  `DatumRodjenja` DATE NULL,
  `Sifra` CHAR(15) NULL,
  PRIMARY KEY (`IDIgrac`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Kladionica`.`Liga`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`Liga` (
  `IDLiga` INT NOT NULL AUTO_INCREMENT,
  `VrstaLige` CHAR(20) NULL,
  PRIMARY KEY (`IDLiga`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Kladionica`.`Sport`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`Sport` (
  `IDSport` INT NOT NULL AUTO_INCREMENT,
  `OpisSporta` CHAR(25) NULL,
  `Liga` INT NOT NULL,
  PRIMARY KEY (`IDSport`),
  INDEX `fk_Sport_Liga1_idx` (`Liga` ASC),
  CONSTRAINT `fk_Sport_Liga1`
    FOREIGN KEY (`Liga`)
    REFERENCES `Kladionica`.`Liga` (`IDLiga`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Kladionica`.`Par`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`Par` (
  `IDPar` INT NOT NULL AUTO_INCREMENT,
  `Naziv` CHAR(25) NULL,
  `SportID` INT NULL,
  PRIMARY KEY (`IDPar`),
  INDEX `fk_Par_Sport1_idx` (`SportID` ASC),
  CONSTRAINT `fk_Par_Sport1`
    FOREIGN KEY (`SportID`)
    REFERENCES `Kladionica`.`Sport` (`IDSport`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Kladionica`.`Dogadjaj`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`Dogadjaj` (
  `IDDogadjaj` INT NOT NULL AUTO_INCREMENT,
  `Datum` DATE NULL,
  `VrijemeOdrzavanja` TIME NULL,
  `Par_ID` INT NOT NULL,
  PRIMARY KEY (`IDDogadjaj`),
  INDEX `fk_Dogadjaj_Par1_idx` (`Par_ID` ASC),
  CONSTRAINT `fk_Dogadjaj_Par1`
    FOREIGN KEY (`Par_ID`)
    REFERENCES `Kladionica`.`Par` (`IDPar`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `Kladionica`.`Tiket`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`Tiket` (
  `IDTiket` CHAR(40) NOT NULL,
  `DatumUplate` DATE NULL,
  `VrijemeUplate` TIME NULL,
  `KontrolniBrojTiketa` VARCHAR(9) NULL,
  `IznosUplate` FLOAT(10) NULL,
  `Sistem` INT(10) NULL,
  `SifraUplatnogMjesta_Sifra` VARCHAR(9) NULL,
  `ZaposleniID` INT NULL,
  `IgracID` INT(10) NULL,
  PRIMARY KEY (`IDTiket`),
  INDEX `fk_Tiket_SifraUplatnogMjesta_idx` (`SifraUplatnogMjesta_Sifra` ASC),
  INDEX `fk_Tiket_Zaposleni1_idx` (`ZaposleniID` ASC),
  INDEX `fk_Tiket_Igrac1_idx` (`IgracID` ASC),
  CONSTRAINT `fk_Tiket_SifraUplatnogMjesta`
    FOREIGN KEY (`SifraUplatnogMjesta_Sifra`)
    REFERENCES `Kladionica`.`SifraUplatnogMjesta` (`Sifra`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Tiket_Zaposleni1`
    FOREIGN KEY (`ZaposleniID`)
    REFERENCES `Kladionica`.`Zaposleni` (`IDZaposleni`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Tiket_Igrac1`
    FOREIGN KEY (`IgracID`)
    REFERENCES `Kladionica`.`Igrac` (`IDIgrac`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `Kladionica`.`TipIgre`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`TipIgre` (
  `IDTipIgre` INT NOT NULL AUTO_INCREMENT,
  `VrstaIgre` CHAR(10) NULL,
  PRIMARY KEY (`IDTipIgre`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Kladionica`.`Dogadjaj_Tiket`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`Dogadjaj_Tiket` (
  `DogadjajID` INT NOT NULL,
  `TiketID` CHAR(40) NOT NULL,
  `TipIgreID` INT NOT NULL,
  PRIMARY KEY (`DogadjajID`, `TiketID`),
  INDEX `fk_Dogadjaj_Tiket_Tiket1_idx` (`TiketID` ASC),
  INDEX `fk_Dogadjaj_Tiket_TipIgre1_idx` (`TipIgreID` ASC),
  CONSTRAINT `fk_Dogadjaj_Tiket_Dogadjaj1`
    FOREIGN KEY (`DogadjajID`)
    REFERENCES `Kladionica`.`Dogadjaj` (`IDDogadjaj`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Dogadjaj_Tiket_Tiket1`
    FOREIGN KEY (`TiketID`)
    REFERENCES `Kladionica`.`Tiket` (`IDTiket`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Dogadjaj_Tiket_TipIgre1`
    FOREIGN KEY (`TipIgreID`)
    REFERENCES `Kladionica`.`TipIgre` (`IDTipIgre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Kladionica`.`Sport_TipIgre`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`Sport_TipIgre` (
  `TipIgre_ID` INT NOT NULL,
  `Sport_ID` INT NOT NULL,
  PRIMARY KEY (`TipIgre_ID`, `Sport_ID`),
  INDEX `fk_Sport_TipIgre_Sport1_idx` (`Sport_ID` ASC),
  CONSTRAINT `fk_Sport_TipIgre_TipIgre1`
    FOREIGN KEY (`TipIgre_ID`)
    REFERENCES `Kladionica`.`TipIgre` (`IDTipIgre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Sport_TipIgre_Sport1`
    FOREIGN KEY (`Sport_ID`)
    REFERENCES `Kladionica`.`Sport` (`IDSport`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Kladionica`.`TipIgre_Par`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Kladionica`.`TipIgre_Par` (
  `TipIgreID` INT NOT NULL,
  `ParID` INT NOT NULL,
  `Kvota` FLOAT(10) NULL,
  `Pogodak` INT(10) NULL,
  PRIMARY KEY (`TipIgreID`, `ParID`),
  INDEX `fk_TipIgre_Par_Par1_idx` (`ParID` ASC),
  CONSTRAINT `fk_TipIgre_Par_TipIgre1`
    FOREIGN KEY (`TipIgreID`)
    REFERENCES `Kladionica`.`TipIgre` (`IDTipIgre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TipIgre_Par_Par1`
    FOREIGN KEY (`ParID`)
    REFERENCES `Kladionica`.`Par` (`IDPar`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;





SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
