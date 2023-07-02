-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 23 Cze 2023, 10:07
-- Wersja serwera: 10.4.25-MariaDB
-- Wersja PHP: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `projekt`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dane`
--

CREATE TABLE `dane` (
  `id` int(11) NOT NULL,
  `zmienna_id` int(11) NOT NULL,
  `kraj_id` int(11) NOT NULL,
  `rok` int(11) NOT NULL,
  `miesiac` int(11) NOT NULL,
  `wartosc` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `kraj`
--

CREATE TABLE `kraj` (
  `id` int(11) NOT NULL,
  `nazwa` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `kraj`
--

INSERT INTO `kraj` (`id`, `nazwa`) VALUES
(1, 'Polska');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `role`
--

CREATE TABLE `role` (
  `Id` int(11) NOT NULL,
  `Role_` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `role`
--

INSERT INTO `role` (`Id`, `Role_`) VALUES
(1, 'admin'),
(2, 'number'),
(3, 'user');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `typ_danej`
--

CREATE TABLE `typ_danej` (
  `id` int(11) NOT NULL,
  `nazwa` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `typ_danej`
--

INSERT INTO `typ_danej` (`id`, `nazwa`) VALUES
(1, 'Bezrobotni zarejestrowani');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `userroles`
--

CREATE TABLE `userroles` (
  `users_id` int(11) DEFAULT NULL,
  `role_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `userroles`
--

INSERT INTO `userroles` (`users_id`, `role_id`) VALUES
(1, 1),
(2, 2),
(2, 3),
(3, 3),
(4, 1),
(4, 2),
(4, 3);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Username` text DEFAULT NULL,
  `Password` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`Id`, `Username`, `Password`) VALUES
(1, 'Andrzej', 'Andrzej'),
(2, 'Piotrek', 'Piotrek'),
(3, 'Ania', 'Ania'),
(4, 'test', 'testing');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `dane`
--
ALTER TABLE `dane`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_kraj_id` (`kraj_id`),
  ADD KEY `fk_zmienna_id` (`zmienna_id`);

--
-- Indeksy dla tabeli `kraj`
--
ALTER TABLE `kraj`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`Id`);

--
-- Indeksy dla tabeli `typ_danej`
--
ALTER TABLE `typ_danej`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `userroles`
--
ALTER TABLE `userroles`
  ADD KEY `users_id` (`users_id`),
  ADD KEY `role_id` (`role_id`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `dane`
--
ALTER TABLE `dane`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=148;

--
-- AUTO_INCREMENT dla tabeli `kraj`
--
ALTER TABLE `kraj`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `role`
--
ALTER TABLE `role`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `typ_danej`
--
ALTER TABLE `typ_danej`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `dane`
--
ALTER TABLE `dane`
  ADD CONSTRAINT `fk_kraj_id` FOREIGN KEY (`kraj_id`) REFERENCES `kraj` (`id`),
  ADD CONSTRAINT `fk_zmienna_id` FOREIGN KEY (`zmienna_id`) REFERENCES `typ_danej` (`id`);

--
-- Ograniczenia dla tabeli `userroles`
--
ALTER TABLE `userroles`
  ADD CONSTRAINT `userroles_ibfk_1` FOREIGN KEY (`users_id`) REFERENCES `users` (`Id`),
  ADD CONSTRAINT `userroles_ibfk_2` FOREIGN KEY (`role_id`) REFERENCES `role` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
