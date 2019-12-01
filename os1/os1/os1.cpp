#include "pch.h"
#include <iostream>
#include <windows.h>
#include <conio.h>
#include <stdlib.h>
#include <VersionHelpers.h>
#include "tlhelp32.h"
#include "iostream"
#include "windows.h"
#define MAX_COMPUTERNAME_LENGTH 15
using namespace std;
int main()
{
	setlocale(0, "");
	WCHAR Cname[MAX_COMPUTERNAME_LENGTH + 1], Uname[MAX_COMPUTERNAME_LENGTH + 1], buf[255], buf1[255], buf2[255];
	char oem[sizeof(Cname) / sizeof(WCHAR)];
	DWORD size = sizeof(Cname) / sizeof(WCHAR);
	LCID lc = GetSystemDefaultLCID();
	OSVERSIONINFO OSInf;

	cout << "Имя компьютера и пользователя:" << endl;
	GetComputerName(Cname, &size);
	GetUserName(Uname, &size);
	wcout << Cname << " " << Uname << endl << endl;

	cout << "Пути к системным каталогам:" << endl;
	GetSystemDirectory(buf, sizeof(buf) / sizeof(WCHAR));
	GetWindowsDirectory(buf1, sizeof(buf1) / sizeof(WCHAR));
	GetTempPath(sizeof(buf2) / sizeof(WCHAR), buf2);
	wcout << buf << endl << buf1 << endl << buf2 << endl << endl;

	OSVERSIONINFO osversion = { 0 };//задаем параметр

	osversion.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);//размер структуры

	
	if (IsWindows8Point1OrGreater())
	{
		cout << "Версия системы (Основной номер. дополнительный. сборка)" << " 8.1" << endl;
	}
	else if (IsWindows8OrGreater())
	{
		cout << "Версия системы (Основной номер. дополнительный. сборка)" << " 10" << endl;
	}
	else if (IsWindows7OrGreater())
	{
		cout << "Версия системы (Основной номер. дополнительный. сборка)" << " 7" << endl;
	}
	else if (IsWindowsVistaOrGreater())
	{
		cout << "Версия системы (Основной номер. дополнительный. сборка)" << " Vista" << endl;
	}
	else if (IsWindowsXPOrGreater())
	{
		cout << "Версия системы (Основной номер. дополнительный. сборка)" << " XP" << endl;
	}

	cout << "Размер структуры OSVERSIONINFO: " << osversion.dwOSVersionInfoSize << endl

		<< "Платформа операционной системы: " << osversion.dwPlatformId << endl    //0=Windows

		<< "Последний установленный служебный пакет: " << osversion.szCSDVersion << endl;  //Пакет не установлен


	cout << "Системные метрики (Ширина и высота области приложения в полноэкранном/Наличие колеса прокрутки):" << endl;
	cout << "[" << GetSystemMetrics(SM_CXFULLSCREEN) << "," << GetSystemMetrics(SM_CYFULLSCREEN) << "]" << '/' << GetSystemMetrics(SM_MOUSEWHEELPRESENT) << endl << endl;

	int param;
	cout << "Системные параметры:" << endl;
	SystemParametersInfo(SPI_GETDEFAULTINPUTLANG, 0, &param, 0);
	cout << param << " - Дискриптор раскладки клавиатуры" << endl;
	SystemParametersInfo(SPI_GETBEEP, 0, &param, 0);
	cout << param << " - Звуковые сигналы" << endl << endl;

	cout << "Системные цвета:" << endl;
	DWORD col[] = { GetSysColor(COLOR_ACTIVECAPTION),GetSysColor(COLOR_WINDOW) };
	cout << "Нынешние цвета: " << col[0] << "/" << col[1] << endl;
	DWORD Colors[] = { RGB(125,200,0),RGB(125,200,255) };
	int Elements[] = { COLOR_WINDOW,COLOR_WINDOW };
	SetSysColors(COLOR_ACTIVECAPTION, Elements, Colors);

	cout << "Функции для работы со временем:" << endl;
	SYSTEMTIME loctime, systime;
	GetLocalTime(&loctime);
	GetSystemTime(&systime);
	cout << "Системное время:" << systime.wDay << "/" << systime.wMonth << "/" << systime.wYear << "/" << systime.wHour << ":" << systime.wMinute << ":" << systime.wSecond << ":" << systime.wMilliseconds << endl;
	cout << "Локальное время:" << loctime.wDay << "/" << loctime.wMonth << "/" << loctime.wYear << "/" << loctime.wHour << ":" << loctime.wMinute << ":" << loctime.wSecond << ":" << loctime.wMilliseconds << endl << endl;

	cout << "Функция CharToOem:" << endl;
	CharToOem(Cname, oem);
	cout << oem << endl << endl;

	cout << "Функция GetCursor:" << endl;
	cout << GetCursor() << endl << endl;

	cout << "Функция GetLocaleInfo:" << endl;
	GetLocaleInfo(lc, LOCALE_SENGLANGUAGE, buf, sizeof(buf) / sizeof(WCHAR));
	wcout << buf << endl << endl;

	cout << "Функция OemToCharBuff:" << endl;
	OemToCharBuff(oem, Cname, sizeof(oem));
	wcout << Cname << endl << endl;

	system("pause");
	SetSysColors(COLOR_ACTIVECAPTION, Elements, col);
}

