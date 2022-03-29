#include "include/dialogWrap.h"

DLL_EXPORT wide_str Char2Cstr(c_str str) {

    TCHAR* ret = (TCHAR*)malloc(sizeof(TCHAR) * str.length);
    int len = str.length;

    #ifdef UNICODE
    len = MultiByteToWideChar(CP_ACP, MB_PRECOMPOSED, str.string, str.length, ret, sizeof(TCHAR) * str.length);
    #else
    strcpy(ret, str);
    #endif
        
    return wide_str(ret, len);

}

DLL_EXPORT c_str Cstr2Char(wide_str str) {

    char* ret = (char*)malloc(sizeof(char) * str.length);
    int len = str.length;

    #ifdef UNICODE
    len = WideCharToMultiByte(CP_ACP, 0, &str.string[0], lstrlen(str.string), &ret[0], str.length, NULL, NULL);
    #else
    strcpy(ret, str);
    #endif

    return c_str(ret, len);

}

DLL_EXPORT char* ShowFileFialog(HWND hwnd, c_str filepath) {

    static OPENFILENAME     ofn;
    static TCHAR* def_path = Char2Cstr(filepath).string;
    static TCHAR* got_file = (TCHAR*)malloc(sizeof(TCHAR) * MAX_PATH);

    if (def_path[0] == TEXT('\0')) {
        GetCurrentDirectory(MAX_PATH, def_path);
    }
    if (ofn.lStructSize == 0) {
        ofn.lStructSize = sizeof(OPENFILENAME);
        ofn.hwndOwner = hwnd;
        ofn.lpstrInitialDir = def_path;       // 初期フォルダ位置
        ofn.lpstrFile = got_file;       // 選択ファイル格納
        ofn.nMaxFile = MAX_PATH;
        ofn.lpstrFilter = TEXT("動画ファイル(*.mp4,*.avi)\0*.mp4;*.avi\0")
            TEXT("MP4ファイル(*.mp4)\0*.mp4\0")
            TEXT("AVIファイル(*.avi)\0*.avi\0")
            TEXT("すべてのファイル(*.*)\0*.*\0");
        ofn.lpstrTitle = TEXT("動画ファイルを開く");
        ofn.Flags = OFN_FILEMUSTEXIST;
    }

    if (GetOpenFileName(&ofn)) {
        return Cstr2Char(wide_str(got_file, MAX_PATH)).string;
    }
    else {
        return nullptr;
    }

}
